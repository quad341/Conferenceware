using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class CompanyController : Controller
	{
		private readonly IRepository _repoository;

		public CompanyController()
			: this(new ConferencewareRepository())
		{
			// no more work
		}

		public CompanyController(IRepository repoository)
		{
			_repoository = repoository;
		}

		//
		// GET: /Company/
		//
		public ActionResult Index()
		{
			return View("Index", _repoository.GetAllCompanies());
		}

		//
		// GET: /Company/Details/5
		//
		public ActionResult Details(int id)
		{
			Company company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			return View("Details", company);
		}

		//
		// GET: /Company/Create
		//
		public ActionResult Create()
		{
			return View("Create", new Company());
		}

		//
		// POST: /Company/Create
		//
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var companyToCreate = new Company();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(companyToCreate,
							   new[]
			                   	{
			                   		"name",
			                   		"address_line1",
			                   		"address_line2",
			                   		"city",
			                   		"state",
			                   		"zip",
			                   		"needs_power",
			                   		"priority_shipping"
			                   	},
							   collection))
			{
				if (companyToCreate.address_line2 == null)
				{
					companyToCreate.address_line2 = "";
				}
				_repoository.AddCompany(companyToCreate);
				_repoository.Save();

				TempData["Message"] = "Company Created";
				return RedirectToAction("Index");
			}
			return View("Create", companyToCreate);
		}

		//
		// GET: /Company/Edit/5
		//
		public ActionResult Edit(int id)
		{
			Company company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			return View("Edit", company);
		}

		//
		// POST: /Company/Edit/5
		//
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			Company company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(company, collection))
			{
				_repoository.Save();
				return RedirectToAction("Details", new { id });
			}
			return View("Edit", company);
		}

		//
		// GET: /Company/Delete/5
		//
		public ActionResult Delete(int id)
		{
			Company company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			return View("Delete", company);
		}

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			Company company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			try
			{
				foreach(var invoice in company.CompanyInvoices)
				{
					foreach (var cii in invoice.CompanyInvoiceItems)
					{
						_repoository.DeleteCompanyInvoiceItem(cii);
					}
					_repoository.Save();
					_repoository.DeleteCompanyInvoice(invoice);
				}
				foreach (var payment in company.CompanyPayments)
				{
					_repoository.DeleteCompanyPayment(payment);
				}
				foreach (var cp in company.CompanyPersons)
				{
					_repoository.DeleteCompanyPerson(cp);
				}
				_repoository.Save();
				_repoository.DeleteCompany(company);
				_repoository.Save();
				TempData["Message"] = "Company deleted";
			}
			catch
			{
				TempData["Message"] =
					"An error occurred deleting the company or one of its dependants";
			}
			return RedirectToAction("Index");
		}
	}
}