using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
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
			Attendee newAttendee = null;
			BindAttendeeData(ref newAttendee, collection, ModelState);
			if (ModelState.IsValid)
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
			BindAttendeeData(ref att, collection, ModelState);
			if (ModelState.IsValid)
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

		private static void BindAttendeeData(ref Attendee attendee, NameValueCollection collection, ModelStateDictionary dictionary)
		{
			// this should also run validations and add stuff to the model state when they fail
			// TODO: Validate data
			if (attendee == null)
			{
				attendee = new Attendee();
				attendee.person_id = 0;
				attendee.People = new People();
				attendee.People.id = attendee.person_id;
			}
			attendee.People.name = collection["Attendee.People.name"];
			attendee.People.email = collection["Attendee.People.email"];
			attendee.People.phone_number = collection["Attendee.People.phone_number"];
			attendee.food_choice_id = int.Parse(collection["Attendee.food_choice_id"]);
			attendee.tshirt_id = int.Parse(collection["Attendee.tshirt_id"]);
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
