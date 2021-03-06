﻿using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class CompanyPersonController : Controller
	{
		private readonly IRepository _repository;

		public CompanyPersonController()
			: this(new ConferencewareRepository())
		{
			// no more work
		}

		public CompanyPersonController(IRepository repository)
		{
			_repository = repository;
		}

		//
		// GET: /CompanyPerson/
		//
		public ActionResult Index()
		{
			// we don't want to deal with lists of all company people; really we just want to manage
			// companies and then related details
			return RedirectToAction("Index", "Company");
		}

		//
		// GET: /CompanyPerson/Create
		//
		public ActionResult Create(int id)
		{
			Company company = _repository.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			var cp = new CompanyPerson { Company = company };
			return View("Create", cp);
		}

		//
		// POST: /CompanyPerson/Create
		//
		[HttpPost]
		public ActionResult Create(CompanyPerson cpToCreate)
		{
			if (ModelState.IsValid)
			{
				_repository.AddCompanyPerson(cpToCreate);
				_repository.Save();
				return RedirectToAction("Details",
										"Company",
										new { id = cpToCreate.company_id });
			}
			return View("Create", cpToCreate);
		}

		//
		// GET: /CompanyPerson/Edit/5
		//
		public ActionResult Edit(int id)
		{
			CompanyPerson cp = _repository.GetCompanyPersonById(id);
			if (cp == null)
			{
				return View("CompanyPersonNotFound");
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPerson/Edit/5
		//
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			CompanyPerson cp = _repository.GetCompanyPersonById(id);
			if (cp == null)
			{
				return View("CompanyPersonNotFound");
			}
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(cp, collection))
			{
				_repository.Save();
				return RedirectToAction("Details", "Company", new { id = cp.company_id });
			}
			return View("Edit", cp);
		}

		//
		// POST: /CompanyPerson/Delete/5
		//
		[HttpPost]
		public ActionResult Delete(int person_id)
		{
			CompanyPerson cp = _repository.GetCompanyPersonById(person_id);
			if (cp == null)
			{
				return View("CompanyPersonNotFound");
			}
			TempData["Message"] = cp.People.name + " has been deleted";
			_repository.DeleteCompanyPerson(cp);
			_repository.Save();
			return RedirectToAction("Details", "Company", new { id = cp.company_id });
		}
	}
}