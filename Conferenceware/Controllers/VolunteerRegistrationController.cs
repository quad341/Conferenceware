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
			return View("Index",
						VolunteerController.CreateEditDataFromVolunteer(
							new Volunteer(), _repository));
		}

		//
		// POST: /VolunteerRegistration/Create

		[HttpPost]
		public ActionResult Index(VolunteerEditData ved)
		{
			if (ModelState.IsValid)
			{
				_repository.AddVolunteer(ved.Volunteer);
				_repository.Save();
				foreach (var i in ved.ChosenTimeSlots)
				{
					var vts = _repository.GetVolunteerTimeSlotById(i);
					if (vts != null)
					{
						_repository.RegisterVolunteerForVolunteerTimeSlot(ved.Volunteer, vts);
					}
				}
				_repository.Save();
				var settings = SettingsData.FromCurrent(
					SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
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
