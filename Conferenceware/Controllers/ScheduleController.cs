using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class ScheduleController : Controller
	{
		private readonly IRepository _repository;

		public ScheduleController()
			: this(new ConferencewareRepository())
		{
			//nothing to do here
		}

		public ScheduleController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /Schedule/

		public ActionResult Index()
		{
			if (!SettingsData.Default.ShowEvents)
			{
				return View("InformationUnavailable");
			}
			IQueryable<Event> events = _repository.GetAllEvents();
			return View("Index", events.OrderBy(e => e.TimeSlot.start_time));
		}

		public ActionResult Details(int id)
		{
			if (!SettingsData.Default.ShowEvents)
			{
				return View("InformationUnavailable");
			}
			Event ev = _repository.GetEventById(id);
			return ev == null ? View("EventNotFound") : View("Details",ev);
		}

		[HttpPost]
		public ActionResult RegisterAttendee(int eventId, string email)
		{
			if (!SettingsData.Default.ShowEvents)
			{
				return View("InformationUnavailable");
			}
			Event ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			Attendee attendee =
				_repository.GetAllAttendees().SingleOrDefault(x => x.People.email == email);
			if (attendee == null)
			{
				TempData["Message"] =
					"Email address not found. Did you remember to register first?";
			}
			else if (ev.max_attendees <= ev.Attendees.Count())
			{
				TempData["Message"] =
					"The event became full when trying to register. Sorry for the trouble.";
			}
			else
			{
				_repository.RegisterAttendeeForEvent(attendee, ev);
				_repository.Save();
				TempData["Message"] = "You were successfully registered for the event!";
				// eventually this should actually work; should determine how to connect to smtp server; 
				// maybe add the setting to the settings data object
				SettingsData settings = SettingsData.Default;
				var message = new MailMessage(settings.EmailFrom,
											  email,
											  String.Format(
												settings.
													EventRegistrationConfirmationSubjectFormat,
												ev.name),
											  String.Format(
												settings.
													EventRegistrationConfirmationBodyFormat,
												ev.name,
												ev.TimeSlot.StringValue,
												ev.Location.StringValue));
				//TODO find out what happens if this fails
				Mailer.Send(message);
			}
			return RedirectToAction("Details", new { id = eventId });
		}

		public ActionResult Videos()
		{
			if (!SettingsData.Default.ShowEvents)
			{
				return View("InformationUnavailable");
			}
			IOrderedQueryable<EventContentLink> videos =
				_repository.GetAllEventContentLinks().Where(x => x.list_on_video_page).
					OrderBy(x => x.Event.name);
			return View("Videos", videos);
		}
	}
}