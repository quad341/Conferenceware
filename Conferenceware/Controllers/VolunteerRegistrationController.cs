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
			if (SettingsData.Default.VolunteerRegistrationAutoCloseDateTime < DateTime.Now
				|| SettingsData.Default.MaxVolunteers <= _repository.GetAllVolunteers().Count())
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
			if (SettingsData.Default.VolunteerRegistrationAutoCloseDateTime < DateTime.Now
				|| SettingsData.Default.MaxVolunteers <= _repository.GetAllVolunteers().Count())
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
				Mailer.Send(message);
				return RedirectToAction("Success");
			}
			ved.VolunteerTimeSlots = _repository.GetAllVolunteerTimeSlots();
			return View("Index", ved);
		}

		// GET: /VolunteerRegistration/Success

		public ActionResult Success()
		{
			return View("Success");
		}
	}
}