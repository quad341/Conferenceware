using System;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
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

		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		public ActionResult Create(int id)
		{
			var invoice = _repository.GetCompanyInvoiceById(id);
			if (invoice == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			var cii = new CompanyInvoiceItem { CompanyInvoice = invoice };
			return View("Create", cii);
		}

		//
		// POST: /CompanyInvoiceItem/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var cii = new CompanyInvoiceItem();
			if (TryUpdateModel(cii, new[] { "name", "description", "cost", "invoice_id" }))
			{

				_repository.AddCompanyInvoiceItem(cii);
				cii.CompanyInvoice.created = DateTime.Now;
				_repository.Save();
				return RedirectToAction("Edit", "CompanyInvoice", new { id = cii.invoice_id });
			}
			return View("Create", cii);
		}

		//
		// GET: /CompanyInvoiceItem/Delete/5

		public ActionResult Delete(int ItemId)
		{
			var cii = _repository.GetCompanyInvoiceItemById(ItemId);
			if (cii == null)
			{
				return View("CompanyInvoiceItemNotFound");
			}
			int invoiceId = cii.invoice_id;
			_repository.DeleteCompanyInvoiceItem(cii);
			_repository.Save();
			return RedirectToAction("Edit", "CompanyInvoice", new { id = invoiceId });
		}
	}
}
