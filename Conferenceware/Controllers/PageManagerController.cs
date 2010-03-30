using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class PageManagerController : Controller
	{
		private readonly IRepository _repository;

		public PageManagerController()
			: this(new ConferencewareRepository())
		{
			// done
		}

		public PageManagerController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /PageManager/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllPages());
		}

		//
		// GET: /PageManager/Details/5

		public ActionResult Details(int id)
		{
			return View("Details", _repository.GetPageById(id));
		}

		//
		// GET: /PageManager/Create

		public ActionResult Create()
		{
			return View("Create", MakeEditDataFromPage(new Page()));
		}

		//
		// POST: /PageManager/Create

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Create(FormCollection collection)
		{
			var page = new Page();
			if (_repository.GetPageByTitle(collection["Page.title"]) != null)
			{
				ModelState.AddModelError("Page.title", "Page title must be unique");
			}
			if (TryUpdateModel(page, "Page"))
			{
				page.title = page.title.Trim();
				_repository.AddPage(page);
				_repository.Save();
				TempData["Message"] = "Page added";
				return RedirectToAction("Index");
			}
			return View("Create", MakeEditDataFromPage(page));
		}

		//
		// GET: /PageManager/Edit/5

		public ActionResult Edit(int id)
		{
			var page = _repository.GetPageById(id);
			if (page == null)
			{
				return View("PageNotFound");
			}
			return View("Edit", MakeEditDataFromPage(page));
		}

		//
		// POST: /PageManager/Edit/5

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var page = _repository.GetPageById(id);
			if (page == null)
			{
				return View("PageNotFound");
			}
			if (_repository.GetPageByTitle(collection["Page.title"]) != null)
			{
				ModelState.AddModelError("Page.title", "Page title must be unique");
			}
			if (TryUpdateModel(page, "Page"))
			{
				page.title = page.title.Trim();
				_repository.Save();
				TempData["Message"] = "Page updated";
				return RedirectToAction("Index");
			}
			return View("Edit", MakeEditDataFromPage(page));
		}

		//
		// GET: /PageManager/Delete/5

		public ActionResult Delete(int id)
		{
			var page = _repository.GetPageById(id);
			if (page == null)
			{
				return View("PageNotFound");
			}
			return View("Delete", page);
		}

		//
		// POST: /PageManager/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			var page = _repository.GetPageById(id);
			if (page == null)
			{
				return View("PageNotFound");
			}
			_repository.DeletePage(page);
			_repository.Save();
			TempData["Message"] = "Page deleted";
			return RedirectToAction("Index");
		}

		private PageEditData MakeEditDataFromPage(Page page)
		{
			return new PageEditData
					{
						Page = page,
						ExistingPages = _repository.GetAllPages()
					};
		}
	}
}
