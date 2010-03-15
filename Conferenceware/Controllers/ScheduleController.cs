using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Conferenceware.Models;

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
			var events = _repository.GetAllEvents();
			var timeslots = _repository.GetAllTimeSlots();
			return View("Index", events.OrderBy(e => e.TimeSlot.start_time));
		}

		public ActionResult Details(int id)
		{
			var ev = _repository.GetEventById(id);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			return View(ev);
		}

		[HttpPost]
		public ActionResult RegisterAttendee(int eventId, string email)
		{
			var ev = _repository.GetEventById(eventId);
			if (ev == null)
			{
				return View("EventNotFound");
			}
			var attendee =
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
				/*
				// eventually this should actually work; should determine how to connect to smtp server; 
				// maybe add the setting to the settings data object
				var settings = SettingsData.FromCurrent(SettingsData.RESOURCE_FILE_NAME);
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
				var smtpclient = new SmtpClient();
				smtpclient.Send(message);
				 */

			}
			return RedirectToAction("Details", new { id = eventId });
		}
	}
}
