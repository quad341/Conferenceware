using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class VolunteerRegistrationController : Controller
	{
		private readonly IRepository _repository;

		public VolunteerRegistrationController()
			: this(new ConferencewareRepository())
		{
			// all done
		}

		public VolunteerRegistrationController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /VolunteerRegistration/Create

		public ActionResult Index()
		{
			if (!VolunteerRegistrationOpen())
			{
				return View("RegistrationClosed");
			}
			return View("Index",
						VolunteerController.CreateEditDataFromVolunteer(
							new Volunteer(), _repository));
		}

		//
		// POST: /VolunteerRegistration/Create

		[HttpPost]
		public ActionResult Index(VolunteerEditData ved)
		{
			if (!VolunteerRegistrationOpen())
			{
				return View("RegistrationClosed");
			}
			if (ModelState.IsValid)
			{
				_repository.AddVolunteer(ved.Volunteer);
				_repository.Save();
				foreach (int i in ved.ChosenTimeSlots)
				{
					VolunteerTimeSlot vts = _repository.GetVolunteerTimeSlotById(i);
					if (vts != null)
					{
						_repository.RegisterVolunteerForVolunteerTimeSlot(ved.Volunteer, vts);
					}
				}
				_repository.Save();
				SettingsData settings = SettingsData.Default;
				var message = new MailMessage(settings.EmailFrom,
											  ved.Volunteer.People.email,
											  settings.RegistrationSubject,
											  settings.RegistrationMessage.Replace(
												"{name}", ved.Volunteer.People.name).Replace(
													"{role}", "Volunteer"));
				try
				{
					Mailer.Send(message);
					TempData["Message"] = "Confirmation email successfully sent";
				}
				catch
				{
					//TODO: add something to log this or send it to an admin. possibly just log it and have an interface for it plus a message on /Home/Admin
					TempData["Message"] =
						"An error occurred sending the email confirmation, but registration was successful";
				}
				return RedirectToAction("Success");
			}
			return View("Index", VolunteerController.CreateEditDataFromVolunteer(ved.Volunteer, _repository));
		}

		// GET: /VolunteerRegistration/Success

		public ActionResult Success()
		{
			return View("Success");
		}

		private bool VolunteerRegistrationOpen()
		{
			return !(SettingsData.Default.VolunteerRegistrationAutoCloseDateTime < DateTime.Now
				|| (SettingsData.Default.MaxVolunteers != 0 &&
					SettingsData.Default.MaxVolunteers <= _repository.GetAllVolunteers().Count()));
		}
	}
}