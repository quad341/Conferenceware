using System;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class CompanyInvoiceItemController : Controller
	{
		private readonly IRepository _repository;

		public CompanyInvoiceItemController()
			: this(new ConferencewareRepository())
		{
			// done!
		}

		public CompanyInvoiceItemController(IRepository repository)
		{
			_repository = repository;
		}

		//
		// GET: /CompanyInvoiceItem/
		//
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyInvoiceItem/Create/5
		//
		public ActionResult Create(int id)
		{
			CompanyInvoice invoice = _repository.GetCompanyInvoiceById(id);
			if (invoice == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			var cii = new CompanyInvoiceItem { CompanyInvoice = invoice };
			return View("Create", cii);
		}

		//
		// POST: /CompanyInvoiceItem/Create/5
		//
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var cii = new CompanyInvoiceItem();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(cii,
							   new[] { "name", "description", "cost", "invoice_id" },
							   collection))
			{
				if (cii.description == null)
				{
					cii.description = "";
				}
				_repository.AddCompanyInvoiceItem(cii);
				CompanyInvoice invoice = _repository.GetCompanyInvoiceById(cii.invoice_id);
				invoice.created = DateTime.Now;
				_repository.Save();
				return RedirectToAction("Edit", "CompanyInvoice", new { id = cii.invoice_id });
			}
			return View("Create", cii);
		}

		//
		// GET: /CompanyInvoiceItem/Delete/5
		//
		public ActionResult Delete(int ItemId)
		{
			CompanyInvoiceItem cii = _repository.GetCompanyInvoiceItemById(ItemId);
			if (cii == null)
			{
				return View("CompanyInvoiceItemNotFound");
			}
			int invoiceId = cii.invoice_id;
			CompanyInvoice invoice = _repository.GetCompanyInvoiceById(cii.invoice_id);
			invoice.created = DateTime.Now;
			_repository.DeleteCompanyInvoiceItem(cii);
			_repository.Save();
			return RedirectToAction("Edit", "CompanyInvoice", new { id = invoiceId });
		}
	}
}