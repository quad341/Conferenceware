using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class AttendeeController : Controller
	{
		/// <summary>
		/// Repository to interact with database
		/// </summary>
		private readonly IRepository _repository;

		public AttendeeController()
			: this(new ConferencewareRepository())
		{

		}

		public AttendeeController(IRepository repo)
		{
			_repository = repo;
		}
		//
		// GET: /Speaker/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllAttendees());
		}

		//
		// GET: /Speaker/Create

		public ActionResult Create()
		{
			var data = MakeEditDateFromAttendee(new Attendee());
			return View("Create", data);
		}

		//
		// POST: /Speaker/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var newAttendee = new Attendee();
			if (TryUpdateModel(newAttendee, "Attendee"))
			{
				_repository.AddAttendee(newAttendee);
				_repository.Save();
				return RedirectToAction("Index");
			}
			var data = MakeEditDateFromAttendee(newAttendee);
			return View("Create", data);
		}

		//
		// GET: /Speaker/Edit/5

		public ActionResult Edit(int id)
		{
			var att = _repository.GetAttendeeById(id);
			if (att == null)
			{
				View("AttendeeNotFound");
			}
			return View("Edit", MakeEditDateFromAttendee(att));
		}

		//
		// POST: /Speaker/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var att = _repository.GetAttendeeById(id);
			if (TryUpdateModel(att, "Attendee"))
			{
				_repository.Save();
				return RedirectToAction("Index");
			}
			var data = MakeEditDateFromAttendee(att);
			return View("Edit", data);
		}

		public ActionResult Delete(int id)
		{
			var att = _repository.GetAttendeeById(id);
			if (att == null)
			{
				return View("AttendeeNotFound");
			}
			_repository.DeleteAttendee(att);
			TempData["Message"] = att.People.name + " was deleted";
			_repository.Save();
			return RedirectToAction("Index");
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
