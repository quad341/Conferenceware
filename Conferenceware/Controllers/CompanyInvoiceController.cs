using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

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
		//
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyInvoice/Create
		//
		public ActionResult Create(int id)
		{
			Company company = _repository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			DateTime now = DateTime.Now;
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
		//
		public ActionResult Edit(int id)
		{
			CompanyInvoice ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			return View("Edit", ci);
		}

		//
		// POST: /CompanyInvoice/Edit/5
		//
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			CompanyInvoice ci = _repository.GetCompanyInvoiceById(id);
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
					ModelState.AddModelError("last_sent",
											 "Cannot have sent a message in the future");
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
		//
		public ActionResult Delete(int InvoiceId)
		{
			CompanyInvoice ci = _repository.GetCompanyInvoiceById(InvoiceId);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			return View("Delete", ci);
		}

		//
		// POST: /CompanyInvoice/Delete/5
		//
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			CompanyInvoice ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}

			foreach (CompanyInvoiceItem cii in ci.CompanyInvoiceItems)
			{
				_repository.DeleteCompanyInvoiceItem(cii);
			}
			_repository.Save();
			_repository.DeleteCompanyInvoice(ci);
			_repository.Save();

			TempData["Message"] = "Invoice and all items deleted";

			return RedirectToAction("Details", "Company", new { id = ci.company_id });
		}

		public ActionResult Email(int id)
		{
			var ci = _repository.GetCompanyInvoiceById(id);
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			return View("Email", MakeEmailEditData(ci));
		}

		[HttpPost]
		public ActionResult Email(CompanyInvoiceEmailEditData cieed)
		{
			var ci = _repository.GetCompanyInvoiceById(cieed.CompanyInvoiceId);
			var message = new MailMessage();
			if (ci == null)
			{
				return View("CompanyInvoiceNotFound");
			}
			foreach (var cp in
				cieed.SelectedRecipiants
					.Select(i => _repository.GetCompanyPersonById(i))
					.Where(cp => cp != null && cp.company_id == ci.company_id))
			{
				message.To.Add(cp.People.email);
			}
			if (message.To.Count == 0)
			{
				ModelState.AddModelError("SelectedRecipiants", "No valid recipiants chosen");
			}
			if (ModelState.IsValid)
			{
				try
				{
					message.Body = cieed.Body;
					message.Subject = cieed.Subject;
					message.Attachments.Add(new Attachment(ci.ToPdf(), cieed.InvoiceAttachmentFileName, "application/pdf"));
					Mailer.Send(message);
					TempData["Message"] = "Message sent successfully";
				}
				catch
				{
					TempData["Message"] = "Email failed to send";
				}
				return RedirectToAction("Edit", new {ci.id});
			}
			cieed.PeopleChoices =
				_repository.GetAllCompanyPersons().Where(x => x.company_id == ci.company_id);
			return View("Email", cieed);
		}

		/// <summary>
		/// Helper method to create CompanyInvoiceEmailEditData objects
		/// </summary>
		/// <param name="ci">The company invoice from which to take the id and company id</param>
		/// <returns>A CompanyInvoiceEmailEditData object from the CompanyInvoice</returns>
		private CompanyInvoiceEmailEditData MakeEmailEditData(CompanyInvoice ci)
		{
			var cieed = new CompanyInvoiceEmailEditData
			            	{
								SelectedRecipiants = new int[0],
			            		CompanyInvoiceId = ci.id,
			            		PeopleChoices =
			            			_repository.GetAllCompanyPersons().Where(
			            				x => x.company_id == ci.company_id),
								InvoiceAttachmentFileName = "Invoice" + ci.id //TODO: localize
			            	};
			return cieed;
		}
	}
}