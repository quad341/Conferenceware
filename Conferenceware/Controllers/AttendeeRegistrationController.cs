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
			AttendeeEditData data = MakeEditDateFromAttendee(new Attendee());
			return View("Index", data);
		}

		//
		// POST: /AttendeeRegistration/
		//
		[HttpPost]
		public ActionResult Index(FormCollection collection)
		{
			var newAttendee = new Attendee();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(newAttendee, "Attendee", collection))
			{
				_repository.AddAttendee(newAttendee);
				_repository.Save();
				SettingsData settings = SettingsData.FromCurrent(
					SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
				var message = new MailMessage(settings.EmailFrom,
											  newAttendee.People.email,
											  settings.RegistrationSubject,
											  settings.RegistrationMessage.Replace(
												"{name}", newAttendee.People.name).Replace(
													"{role}", "Attendee"));
				Mailer.Send(message);
				return RedirectToAction("Success");
			}
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

		//
		// This method creates some data for the AttendeeRegistration Form inside the view
		//
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
	}
}