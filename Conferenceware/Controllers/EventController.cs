using System;
using System.IO;
using System.Linq;
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

		public ActionResult Details(int id)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			return View("Details", ev);
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
			var eventToCreate = new Event();

			if (TryUpdateModel(eventToCreate, "Event"))
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

		private EventEditData MakeEditDataFromEvent(Event e)
		{
			var allSpeakers = _repository.GetAllSpeakers().ToList();
			foreach (var listedSpeaker in e.Speakers)
			{
				allSpeakers.Remove(listedSpeaker);
			}
			var allAttendees = _repository.GetAllAttendees().ToList();
			foreach (var listedAttendee in e.Attendees)
			{
				allAttendees.Remove(listedAttendee);
			}
			return new EventEditData
					{
						Event = e,
						Timeslots =
							new SelectList(_repository.GetAllTimeSlots(), "id", "StringValue"),
						Locations =
							new SelectList(_repository.GetAllLocations(), "id", "StringValue"),
						Attendees =
							new SelectList(
							allAttendees.OrderBy(
								x => x.People.name),
							"person_id",
							"People.name"),
						Speakers =
							new SelectList(
							allSpeakers.OrderBy(x => x.People.name),
							"person_id",
							"People.name")
					};
		}

		[HttpPost]
		public ActionResult AddSpeaker(int eventId, int speakerId)
		{
			var speaker = _repository.GetSpeakerById(speakerId);
			if (speaker == null)
			{
				return RedirectToAction("Edit", new { id = eventId });
			}
			Event ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			_repository.RegisterSpeakerForEvent(speaker, ev);
			_repository.Save();
			return RedirectToAction("Edit", new { id = eventId });
		}

		[HttpPost]
		public ActionResult RemoveSpeaker(int eventId, int speakerId)
		{
			var speaker = _repository.GetSpeakerById(speakerId);
			if (speaker == null)
			{
				return RedirectToAction("Edit", new { id = eventId });
			}
			Event ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			_repository.UnRegisterSpeakerForEvent(speaker, ev);
			_repository.Save();
			return RedirectToAction("Edit", new { id = eventId });
		}

		[HttpPost]
		public ActionResult AddAttendee(int eventId, int attendeeId)
		{
			var attendee = _repository.GetAttendeeById(attendeeId);
			if (attendee == null)
			{
				return RedirectToAction("Edit", new { id = eventId });
			}
			Event ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			_repository.RegisterAttendeeForEvent(attendee, ev);
			_repository.Save();
			return RedirectToAction("Edit", new { id = eventId });
		}

		[HttpPost]
		public ActionResult RemoveAttendee(int eventId, int attendeeId)
		{
			var attendee = _repository.GetAttendeeById(attendeeId);
			if (attendee == null)
			{
				return RedirectToAction("Edit", new { id = eventId });
			}
			Event ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			_repository.UnRegisterAttendeeForEvent(attendee, ev);
			_repository.Save();
			return RedirectToAction("Edit", new { id = eventId });
		}

		public ActionResult UploadContent(int id)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			var ecl = new EventContentLink
						{
							Event = ev
						};
			return View("UploadContent", ecl);
		}

		[HttpPost]
		public ActionResult UploadContent(EventContentLink ecl)
		{
			Event ev = _repository.GetEventById(ecl.event_id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			string filename = ProcessUpload(ecl);
			if (ModelState.IsValid)
			{
				// add link
				ecl.link_location = "/Content/" + ecl.event_id + "/" + filename;
				_repository.AddEventContentLink(ecl);
				_repository.Save();
				TempData["Message"] = "Content added";
			}
			return View("UploadContent", ecl);
		}

		private string ProcessUpload(EventContentLink ecl)
		{
			var hpf = Request.Files["link_location"];
			if (hpf == null || hpf.ContentLength == 0)
			{
				ModelState.AddModelError("link_location", "File required");
			}
			var dir = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\" +
					  ecl.event_id + "\\";
			var filename = hpf.FileName;
			if (System.IO.File.Exists(dir + filename))
			{
				var i = 0;
				while (System.IO.File.Exists(dir + i + filename))
				{
					i++;
				}
				filename = i + filename;
			}
			try
			{
				hpf.SaveAs(dir + filename);
			}
			catch
			{
				TempData["Message"] = "Unable to write file";
				ModelState.AddModelError("link_location", "File could not be saved");
			}
			return filename;
		}
	}
}
