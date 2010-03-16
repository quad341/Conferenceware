using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
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

		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyPayment/Create

		public ActionResult Create(int id)
		{
			var company = _repository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			var payment = new CompanyPayment { Company = company };
			return View("Create", payment);
		}

		//
		// POST: /CompanyPayment/Create

		[HttpPost]
		public ActionResult Create(CompanyPayment cp)
		{
			if (ModelState.IsValid)
			{
				_repository.AddCompanyPayment(cp);
				_repository.Save();
				TempData["Message"] = "Payment added";
				return RedirectToAction("Details", "Company", new { id = cp.company_id });
			}
			return View("Create", cp);
		}

		//
		// GET: /CompanyPayment/Edit/5

		public ActionResult Edit(int id)
		{
			var cp = _repository.GetCompanyPaymentById(id);
			if (cp == null)
			{
				return View("CompanyPaymentNotFound");
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPayment/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var cp = _repository.GetCompanyPaymentById(id);
			if (cp == null)
			{
				return View("CompanyPaymentNotFound");
			}
			if (TryUpdateModel(cp))
			{
				_repository.Save();
				TempData["Message"] = "Payment Updated";
				return RedirectToAction("Details", "Company", new { id = cp.company_id });
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPayment/Delete/5

		[HttpPost]
		public ActionResult Delete(int id)
		{
			var cp = _repository.GetCompanyPaymentById(id);
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
