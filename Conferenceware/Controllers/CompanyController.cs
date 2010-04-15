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

		public ActionResult Index()
		{
			return View("Index", _repoository.GetAllCompanies());
		}

		//
		// GET: /Company/Details/5

		public ActionResult Details(int id)
		{
			var company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			return View("Details", company);
		}

		//
		// GET: /Company/Create

		public ActionResult Create()
		{
			return View("Create", new Company());
		}

		//
		// POST: /Company/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var companyToCreate = new Company();
			if (TryUpdateModel(companyToCreate, new[]
			                                    	{
			                                    		"name", 
														"address_line1", 
														"address_line2", 
														"city", 
														"state", 
														"zip", 
														"needs_power", 
														"priority_shipping"
			                                    	}))
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

		public ActionResult Edit(int id)
		{
			var company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			return View("Edit", company);
		}

		//
		// POST: /Company/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			if (TryUpdateModel(company))
			{
				_repoository.Save();
				return RedirectToAction("Details", new { id });
			}
			return View("Edit", company);
		}

		//
		// GET: /Company/Delete/5

		public ActionResult Delete(int id)
		{
			var company = _repoository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			try
			{
				_repoository.DeleteCompany(company);
				_repoository.Save();
				TempData["Message"] = "Company deleted";
			}
			catch
			{
				TempData["Message"] =
					"Company could not be deleted; remove all references first";
			}
			return RedirectToAction("Index");
		}
	}
}
