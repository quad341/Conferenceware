using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class FoodController : Controller
	{
		private readonly IRepository _repository;

		public FoodController()
			: this(new ConferencewareRepository())
		{
			// nothing else to do
		}

		public FoodController(IRepository repo)
		{
			_repository = repo;
		}
		//
		// GET: /Food/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllFoods());
		}

		//
		// GET: /Food/Create

		public ActionResult Create()
		{
			return View("Create", new Food());
		}

		//
		// POST: /Food/Create

		[HttpPost]
		public ActionResult Create(Food foodToCreate)
		{
			if (ModelState.IsValid)
			{
				_repository.AddFood(foodToCreate);
				_repository.Save();

				return RedirectToAction("Index");
			}
			return View("Create", foodToCreate);
		}

		//
		// GET: /Food/Edit/5

		public ActionResult Edit(int id)
		{
			var food = _repository.GetFoodById(id);
			if (food == null)
			{
				return View("FoodIsInvalid");
			}
			return View("Edit", food);
		}

		//
		// POST: /Food/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var food = _repository.GetFoodById(id);
			if (food == null)
			{
				return View("FoodIsInvalid");
			}
			if (ModelState.IsValid)
			{
				//since UpdateModel doesn't work right, i'll do it by hand
				food.name = collection["name"];
				_repository.Save();

				return RedirectToAction("Index");
			}
			return View("Edit", food);
		}

		public ActionResult Delete(int id)
		{
			var food = _repository.GetFoodById(id);
			if (food == null)
			{
				return View("FoodIsInvalid");
			}
			try
			{
				_repository.DeleteFood(food);
				_repository.Save();
				TempData["Message"] = food.name + " was deleted";
			}
			catch
			{
				TempData["Message"] = "Cannot delete item. Remove all references";
			}
			return RedirectToAction("Index");
		}
	}
}
