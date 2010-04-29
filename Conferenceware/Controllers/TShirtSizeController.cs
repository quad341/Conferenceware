using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class TShirtSizeController : Controller
	{
		private readonly IRepository _repository;

		public TShirtSizeController()
			: this(new ConferencewareRepository())
		{
			// nothing more to do
		}

		public TShirtSizeController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /TShirtSize/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllTShirtSizes());
		}

		//
		// GET: /TShirtSize/Create

		public ActionResult Create()
		{
			return View("Create", new TShirtSize());
		}

		//
		// POST: /TShirtSize/Create

		[HttpPost]
		public ActionResult Create(TShirtSize tssToCreate)
		{
			if (ModelState.IsValid)
			{
				_repository.AddTShirtSize(tssToCreate);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Create", tssToCreate);
		}

		//
		// GET: /TShirtSize/Edit/5

		public ActionResult Edit(int id)
		{
			TShirtSize tss = _repository.GetTShirtSizeById(id);
			if (tss == null)
			{
				return View("TShirtSizeNotFound");
			}
			return View("Edit", tss);
		}

		//
		// POST: /TShirtSize/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			TShirtSize tss = _repository.GetTShirtSizeById(id);
			if (tss == null)
			{
				return View("TShirtSizeNotFound");
			}
			if (ModelState.IsValid)
			{
				//UpdateModel doesn't work right
				tss.name = collection["name"];
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Edit", tss);
		}

		public ActionResult Delete(int id)
		{
			TShirtSize tss = _repository.GetTShirtSizeById(id);
			if (tss == null)
			{
				return View("TShirtSizeNotFound");
			}
			try
			{
				_repository.DeleteTShirtSize(tss);
				_repository.Save();
				TempData["Message"] = tss.name + " was deleted";
			}
			catch
			{
				TempData["Message"] = "Cannot delete item. Remove all references";
			}
			return RedirectToAction("Index");
		}
	}
}