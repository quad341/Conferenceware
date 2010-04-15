using System;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class CompanyInvoiceController : Controller
	{
		private readonly IRepository _repository;

		public CompanyInvoiceController()
			: this(new ConferencewareRepository())
		{
			// all good
		}

		public CompanyInvoiceController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /CompanyInvoice/

		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyInvoice/Create

		public ActionResult Create(int id)
		{
			var company = _repository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			var now = DateTime.Now;
			var ci = new CompanyInvoice
						{
							Company = company,
							created = now,
							last_sent = now,
							paid = false,
							marked_paid_date = now
						};
			_repository.AddCompanyInvoice(ci);
			_repository.Save();
			return RedirectToAction("Edit", new { ci.id });
		}

		//
		// GET: /CompanyInvoice/Edit/5

		public ActionResult Edit(int id)
		{
			var ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			return View("Edit", ci);
		}

		//
		// POST: /CompanyInvoice/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			DateTime last_sent;
			if (DateTime.TryParse(collection["last_sent"], out last_sent))
			{
				ci.last_sent = last_sent;
				if (last_sent > DateTime.Now)
				{
					ModelState.AddModelError("last_sent", "Cannot have sent a message in the future");
				}
			}
			else
			{
				ModelState.AddModelError("last_sent", "Invalid date/time provided");
			}
			bool wasPaid = ci.paid;
			ci.paid = collection["paid"] != null && collection["paid"].Contains("true");
			if (ModelState.IsValid)
			{
				if (!wasPaid && ci.paid)
				{
					ci.marked_paid_date = DateTime.Now;
				}
				else if (wasPaid && !ci.paid)
				{
					ci.marked_paid_date = ci.created;
				}
				_repository.Save();
				return RedirectToAction("Details", "Company", new { id = ci.company_id });
			}
			return View("Edit", ci);
		}

		//
		// GET: /CompanyInvoice/Delete/5

		public ActionResult Delete(int InvoiceId)
		{
			var ci = _repository.GetCompanyInvoiceById(InvoiceId);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			return View("Delete", ci);
		}

		//
		// POST: /CompanyInvoice/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			var ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}

			foreach (var cii in ci.CompanyInvoiceItems)
			{
				_repository.DeleteCompanyInvoiceItem(cii);
			}
			_repository.Save();
			_repository.DeleteCompanyInvoice(ci);
			_repository.Save();

			TempData["Message"] = "Invoice and all items deleted";

			return RedirectToAction("Details", "Company", new { id = ci.company_id });
		}
	}
}
