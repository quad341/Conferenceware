using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class EventController : Controller
	{


		/// <summary>
		/// Repository to interact with database
		/// </summary>
		private readonly IRepository _repository;

		public EventController()
			: this(new ConferencewareRepository())
		{
			// nothing more to do
		}

		public EventController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /Event/Create

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllEvents());
		}

		public ActionResult Create()
		{
			return View("Create", MakeEditDataFromEvent(new Event()));
		}

		//
		// POST: /Event/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			Event eventToCreate = null;

			BindEventData(ref eventToCreate, collection, ModelState);

			if (ModelState.IsValid)
			{
				_repository.AddEvent(eventToCreate);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Create", MakeEditDataFromEvent(eventToCreate));
		}

		//
		// GET: /Event/

		//
		// GET: /Event/Edit/5

		public ActionResult Edit(int id)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			return View("Edit", MakeEditDataFromEvent(ev));
		}

		//
		// POST: /Event/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			//BindEventData(ref ev, collection, ModelState);
			//if (ModelState.IsValid)
			if (TryUpdateModel(ev, "Event"))
			{
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Edit", MakeEditDataFromEvent(ev));
		}

		public ActionResult Delete(int id)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			try
			{
				var name = ev.name;
				_repository.DeleteEvent(ev);
				_repository.Save();
				TempData["Message"] = name + " was deleted";
			}
			catch
			{
				TempData["Message"] = "Could not delete event";
			}
			return RedirectToAction("Index");
		}

		private static void BindEventData(ref Event ev, NameValueCollection collection, ModelStateDictionary dictionary)
		{
			// TODO: Validate
			if (ev == null)
			{
				ev = new Event();
				ev.id = 0;
			}
			ev.name = collection["Event.name"];
			ev.description = collection["Event.description"];
			ev.max_attendees = int.Parse(collection["Event.max_attendees"]);
			ev.timeslot_id = int.Parse(collection["Event.timeslot_id"]);
			ev.location_id = int.Parse(collection["Event.location_id"]);
		}

		private EventEditData MakeEditDataFromEvent(Event e)
		{
			return new EventEditData
					{
						Event = e,
						Timeslots = new SelectList(_repository.GetAllTimeSlots(), "id", "StringValue"),
						Locations = new SelectList(_repository.GetAllLocations(), "id", "StringValue")
					};
		}
	}
}
