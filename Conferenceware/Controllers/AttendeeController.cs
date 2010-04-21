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
		// GET: /Attendee/

		//
		// GET: /Attendee/
		//
		public ActionResult Index()
		{
			return View("Index", _repository.GetAllAttendees());
		}

		//
		// GET: /Attendee/Create
		//
		public ActionResult Create()
		{
			var data = MakeEditDateFromAttendee(new Attendee());
			return View("Create", data);
		}

		//
		// POST: /Attendee/Create
		//
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var newAttendee = new Attendee();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(newAttendee, "Attendee", collection))
			{
				_repository.AddAttendee(newAttendee);
				_repository.Save();
				return RedirectToAction("Index");
			}
			var data = MakeEditDateFromAttendee(newAttendee);
			return View("Create", data);
		}

		//
		// GET: /Attendee/Edit/5
		//
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
		// POST: /Attendee/Edit/5
		//
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var att = _repository.GetAttendeeById(id);
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(att, "Attendee", collection))
			{
				_repository.Save();
				return RedirectToAction("Index");
			}
			var data = MakeEditDateFromAttendee(att);
			return View("Edit", data);
		}

		//
		// GET: /Attendee/Delete
		//
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

		//
		// This method creates some data for the Attendee Form inside the view
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
