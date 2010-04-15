using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class TimeSlotController : Controller
	{
		/// <summary>
		/// Repository to interact with database
		/// </summary>
		private readonly IRepository _repository;

		public TimeSlotController()
			: this(new ConferencewareRepository())
		{
			// nothing more to do
		}

		public TimeSlotController(IRepository repo)
		{
			_repository = repo;
		}


		//
		// GET: /TimeSlot/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllTimeSlots());
		}

		//
		// GET: /TimeSlot/Create

		public ActionResult Create()
		{
			return View("Create", new TimeSlot());
		}

		//
		// POST: /TimeSlot/Create

		[HttpPost]
		public ActionResult Create(TimeSlot tsToCreate)
		{
			if (ModelState.IsValid)
			{
				_repository.AddTimeSlot(tsToCreate);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Create", tsToCreate);
		}

		//
		// GET: /TimeSlot/Edit/5

		public ActionResult Edit(int id)
		{
			TimeSlot ts = _repository.GetTimeSlotById(id);
			if (ts == null)
			{
				View("TimeSlotNotFound");
			}
			return View("Edit", ts);
		}

		//
		// POST: /TimeSlot/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			TimeSlot ts = _repository.GetTimeSlotById(id);
			if (TryUpdateModel(ts))
			{
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Edit", ts);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			TimeSlot ts = _repository.GetTimeSlotById(id);
			if (ts == null)
			{
				return View("TimeSlotNotFound");
			}
			try
			{
				_repository.DeleteTimeSlot(ts);
				_repository.Save();
				TempData["Message"] = "Timeslot was deleted";
			}
			catch
			{
				TempData["Message"] =
					"Delete anything depending on timeslot before deleting";
			}
			return RedirectToAction("Index");
		}
	}
}
