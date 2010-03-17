using System.Web.Mvc;
using Conferenceware.Models;

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

		public ActionResult Index()
		{
			var data = MakeEditDateFromAttendee(new Attendee());
			return View("Index", data);
		}

		//
		// POST: /Speaker/Create

		[HttpPost]
		public ActionResult Index(FormCollection collection)
		{
			var newAttendee = new Attendee();
			if (TryUpdateModel(newAttendee, "Attendee"))
			{
				_repository.AddAttendee(newAttendee);
				_repository.Save();
				return RedirectToAction("Success");
			}
			var data = MakeEditDateFromAttendee(newAttendee);
			return RedirectToAction("Index", data);
		}


		public ActionResult Success()
		{
			return View("Success");
		}

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
