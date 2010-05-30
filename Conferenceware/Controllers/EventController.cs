using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
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

			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(eventToCreate, "Event", collection))
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
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(ev, "Event", collection))
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
			return View("Delete", ev);
		}


		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			Event ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			try
			{
				// Unlink speakers from this event
				foreach (Speaker speaker in ev.Speakers)
				{
					_repository.UnRegisterSpeakerForEvent(speaker, ev);
				}
				// Unlink attendees from this event
				foreach (Attendee attendee in ev.Attendees)
				{
					_repository.UnRegisterAttendeeForEvent(attendee, ev);
				}
				string name = ev.name;
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
			List<Speaker> allSpeakers = _repository.GetAllSpeakers().ToList();
			foreach (Speaker listedSpeaker in e.Speakers)
			{
				allSpeakers.Remove(listedSpeaker);
			}
			List<Attendee> allAttendees = _repository.GetAllAttendees().ToList();
			foreach (Attendee listedAttendee in e.Attendees)
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
			Speaker speaker = _repository.GetSpeakerById(speakerId);
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
			Speaker speaker = _repository.GetSpeakerById(speakerId);
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
			Attendee attendee = _repository.GetAttendeeById(attendeeId);
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
			Attendee attendee = _repository.GetAttendeeById(attendeeId);
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
				return RedirectToAction("Edit", new { id = ecl.event_id });
			}
			ecl.Event = _repository.GetEventById(ecl.event_id);
			return View("UploadContent", ecl);
		}

		public ActionResult AddLink(int id)
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
			return View("AddLink", ecl);
		}

		[HttpPost]
		public ActionResult AddLink(EventContentLink ecl)
		{
			// some model checking is done here just because we are exploiting structures above
			// and it means that we will get a null above when we don't want to allow that here
			if (ecl.link_location == null || ecl.link_location.Trim() == "")
			{
				ModelState.AddModelError("link_location", "Link Location is required");
			}
			string contentLocation = Url.Content("~/Content/");
			if (ecl.link_location != null &&
				(!SettingsData.Default.DisableLinkLocationCheck &&
				ecl.link_location.IndexOf(contentLocation) != 0))
			{
				ModelState.AddModelError("link_location",
										 String.Format(
											"Links must start with {0} (files need to be in {0})",
											contentLocation));
			}
			if (ModelState.IsValid)
			{
				_repository.AddEventContentLink(ecl);
				_repository.Save();
				TempData["Message"] = "Link added";
				return RedirectToAction("Edit", new { id = ecl.event_id });
			}
			return View("AddLink", ecl);
		}

		public ActionResult RemoveContentLink(int contentId)
		{
			EventContentLink ecl = _repository.GetEventContentLinkById(contentId);
			if (ecl == null)
			{
				return View("EventContentLinkNotFound");
			}
			return View("RemoveContentLink",
						new EventContentLinkDeleteData { EventContentLink = ecl });
		}

		[HttpPost]
		public ActionResult RemoveContentLink(EventContentLinkDeleteData ecldd)
		{
			EventContentLink ecl =
				_repository.GetEventContentLinkById(ecldd.EventContentLink.id);
			if (ecl == null)
			{
				return View("EventContentLinkNotFound");
			}
			bool errorEncountered = false;
			string fixedPath = AppDomain.CurrentDomain.BaseDirectory +
							   ecl.link_location.Replace('/', '\\').Replace("\\\\", "\\");
			if (ecldd.DeleteFile && System.IO.File.Exists(fixedPath))
			{
				try
				{
					System.IO.File.Delete(fixedPath);
				}
				catch
				{
					errorEncountered = true;
					TempData["Message"] = "Could not delete file";
				}
			}
			if (ecldd.DeleteDir)
			{
				try
				{
					Directory.Delete(fixedPath.Substring(0, fixedPath.LastIndexOf('\\')));
				}
				catch
				{
					TempData["Message"] = "Could not delete directory";
				}
			}
			if (!errorEncountered)
			{
				_repository.DeleteEventContentLink(ecl);
				_repository.Save();
			}
			return RedirectToAction("Edit", new { id = ecl.event_id });
		}

		private string ProcessUpload(EventContentLink ecl)
		{
			HttpPostedFileBase hpf = Request.Files["link_location"];
			if (hpf == null || hpf.ContentLength == 0)
			{
				ModelState.AddModelError("link_location", "File required");
			}
			string dir = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\" +
						 ecl.event_id + "\\";
			string filename = hpf.FileName;
			if (System.IO.File.Exists(dir + filename))
			{
				int i = 0;
				while (System.IO.File.Exists(dir + i + filename))
				{
					i++;
				}
				filename = i + filename;
			}
			try
			{
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
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