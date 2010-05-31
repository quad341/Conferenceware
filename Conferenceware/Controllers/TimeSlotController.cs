using System;
using System.Web.Mvc;
using Conferenceware.Localization;
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
			var ts = new TimeSlot
						{
							start_time = DateTime.Now,
							end_time = DateTime.Now
						};
			return View("Create", ts);
		}

		//
		// POST: /TimeSlot/Create

		[HttpPost]
		public ActionResult Create(TimeSlot tsToCreate)
		{
			if (ModelState.IsValid && TimesMakeSense(tsToCreate, ModelState))
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
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(ts, collection) && TimesMakeSense(ts, ModelState))
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

		/// <summary>
		/// Checks if the times for the timeslot make sense (start time before end, happens during conference)
		/// </summary>
		/// <param name="tsToCreate">The timeslot to check</param>
		/// <param name="modelState">The model state to use when reporting errors</param>
		/// <returns></returns>
		private static bool TimesMakeSense(TimeSlot tsToCreate, ModelStateDictionary modelState)
		{
			var success = true;
			if (tsToCreate.end_time <= tsToCreate.start_time)
			{
				modelState.AddModelError("start_time",
				                         ControllerStrings.
				                         	TimeSlotController_Error_StartBeforeEnd);
				success = false;
			}
			if (!SettingsData.Default.AllowTimeSlotsBeforeStart
				&& tsToCreate.start_time < SettingsData.Default.StartDate)
			{
				modelState.AddModelError("start_time",
				                         ControllerStrings.
				                         	TimeSlotController_Error_StartBeforeConferenceStart);
				success = false;
			}
			if (!SettingsData.Default.AllowTimeSlotsAfterEnd
				&& tsToCreate.end_time > SettingsData.Default.EndDate)
			{
				modelState.AddModelError("end_time",
				                         ControllerStrings.
				                         	TimeSlotController_Error_EndAfterConferenceEnd);
				success = false;
			}
			return success;
		}
	}
}