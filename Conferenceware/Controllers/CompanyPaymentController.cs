using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class CompanyPaymentController : Controller
	{
		private readonly IRepository _repository;

		public CompanyPaymentController()
			: this(new ConferencewareRepository())
		{
			// all good
		}

		public CompanyPaymentController(IRepository repository)
		{
			_repository = repository;
		}

		//
		// GET: /CompanyPayment/
		//
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyPayment/Create
		//
		public ActionResult Create(int id)
		{
			Company company = _repository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			var payment = new CompanyPayment { Company = company };
			return View("Create", payment);
		}

		//
		// POST: /CompanyPayment/Create
		//
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var cp = new CompanyPayment();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(cp,
							   new[] { "company_id", "amount", "received_date", "comments" },
							   collection))
			{
				if (cp.comments == null)
				{
					cp.comments = "";
				}
				_repository.AddCompanyPayment(cp);
				_repository.Save();
				TempData["Message"] = "Payment added";
				return RedirectToAction("Details", "Company", new { id = cp.company_id });
			}
			// if it errors on submit; it only has the id, not the linq object
			Company company = _repository.GetCompanyById(cp.company_id);
			if (company == null)
			{
				// this has happened; not sure why
				TempData["Message"] = "An error has occurred. Please try again";
				RedirectToAction("Index", "Company");
			}
			cp.Company = company;
			return View("Create", cp);
		}

		//
		// GET: /CompanyPayment/Edit/5
		//
		public ActionResult Edit(int id)
		{
			CompanyPayment cp = _repository.GetCompanyPaymentById(id);
			if (cp == null)
			{
				return View("CompanyPaymentNotFound");
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPayment/Edit/5
		//
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			CompanyPayment cp = _repository.GetCompanyPaymentById(id);
			if (cp == null)
			{
				return View("CompanyPaymentNotFound");
			}
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(cp,
							   new[] { "company_id", "amount", "received_date", "comments" },
							   collection))
			{
				if (cp.comments == null)
				{
					cp.comments = "";
				}
				_repository.Save();
				TempData["Message"] = "Payment Updated";
				return RedirectToAction("Details", "Company", new { id = cp.company_id });
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPayment/Delete/5
		//
		[HttpPost]
		public ActionResult Delete(int payment_id)
		{
			CompanyPayment cp = _repository.GetCompanyPaymentById(payment_id);
			if (cp == null)
			{
				return View("CompanyPaymentNotFound");
			}
			_repository.DeleteCompanyPayment(cp);
			_repository.Save();
			TempData["Message"] = "Payment Deleted";
			return RedirectToAction("Details", "Company", new { id = cp.company_id });
		}
	}
}