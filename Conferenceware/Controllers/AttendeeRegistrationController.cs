using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class AttendeeRegistrationController : Controller
	{
		private readonly IRepository _repository;

		public AttendeeRegistrationController()
			: this(new ConferencewareRepository())
		{
			// yay
		}

		public AttendeeRegistrationController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /AttendeeRegistration/
		//
		public ActionResult Index()
		{
			if (!AttendeeRegistrationIsOpen())
			{
				return View("RegistrationClosed");
			}
			AttendeeEditData data = MakeEditDateFromAttendee(new Attendee());
			return View("Index", data);
		}

		//
		// POST: /AttendeeRegistration/
		//
		[HttpPost]
		public ActionResult Index(FormCollection collection)
		{
			if (!AttendeeRegistrationIsOpen())
			{
				return View("RegistrationClosed");
			}
			var newAttendee = new Attendee();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(newAttendee, "Attendee", collection))
			{
				_repository.AddAttendee(newAttendee);
				_repository.Save();
				SettingsData settings = SettingsData.Default;
				//TODO: localize string replacement
				var message = new MailMessage(settings.EmailFrom,
											  newAttendee.People.email,
											  settings.RegistrationSubject,
											  settings.RegistrationMessage.Replace(
												"{name}", newAttendee.People.name).Replace(
													"{role}", "Attendee"));
				try
				{
					Mailer.Send(message);
				}
				catch
				{
					//TODO: log this
				}
				return RedirectToAction("Success");
			}
			// TODO: make validation messages show
			// this isn't showing error messages; eventually that should be investigated
			AttendeeEditData data = MakeEditDateFromAttendee(newAttendee);
			return RedirectToAction("Index", data);
		}

		//
		// GET: /AttendeeRegistration/Success
		//
		public ActionResult Success()
		{
			return View("Success");
		}

		/// <summary>
		/// This method creates some data for the AttendeeRegistration Form inside the view 
		/// </summary>
		/// <param name="attendee">The attendee to put in the edit data</param>
		/// <returns>An AttendeeEditData object containing the Attendee</returns>
		private AttendeeEditData MakeEditDateFromAttendee(Attendee attendee)
		{
			return new AttendeeEditData
					{
						Attendee = attendee,
						Foods = new SelectList(_repository.GetAllFoods(), "id", "name"),
						TShirtSizes =
							new SelectList(_repository.GetAllTShirtSizes(), "id", "name")
					};
		}

		private bool AttendeeRegistrationIsOpen()
		{
			return !(SettingsData.Default.AttendeeRegistrationAutoCloseDateTime < DateTime.Now
				|| (SettingsData.Default.MaxAttendees > 0 &&
					SettingsData.Default.MaxAttendees <= _repository.GetAllAttendees().Count()));
		}
	}
}