using System;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class CompanyController : Controller
	{
		private readonly IRepository _repo;

		CompanyController()
			: this(new ConferencewareRepository())
		{
			// no more work
		}

		CompanyController(IRepository repo)
		{
			_repo = repo;
		}
		//
		// GET: /Company/

		public ActionResult Index()
		{
			return View("Index", _repo.GetAllCompanies());
		}

		//
		// GET: /Company/Details/5

		public ActionResult Details(int id)
		{
			var company = _repo.GetCompanyById(id);
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
		public ActionResult Create(Company companyToCreate)
		{
			if (ModelState.IsValid)
			{
				_repo.AddCompany(companyToCreate);
				_repo.Save();

				TempData["Message"] = "Company Created";
				return RedirectToAction("Index");
			}
			return View("Create", companyToCreate);

		}

		//
		// GET: /Company/Edit/5

		public ActionResult Edit(int id)
		{
			var company = _repo.GetCompanyById(id);
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
			var company = _repo.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			if (TryUpdateModel(company))
			{
				_repo.Save();
				return RedirectToAction("Index");
			}
			return View("Edit", company);
		}

		//
		// GET: /Company/Delete/5

		public ActionResult Delete(int id)
		{
			var company = _repo.GetCompanyById(id);
			if (company == null)
			{
				return View("CompanyNotFound");
			}
			try
			{
				_repo.DeleteCompany(company);
				_repo.Save();
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
