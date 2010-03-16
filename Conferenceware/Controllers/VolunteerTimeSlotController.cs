using System;
using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class VolunteerTimeSlotController : Controller
	{
		private readonly IRepository _repository;

		public VolunteerTimeSlotController()
			: this(new ConferencewareRepository())
		{
			// it's all good
		}

		public VolunteerTimeSlotController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /VolunteerTimeSlot/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllVolunteerTimeSlots());
		}

		//
		// GET: /VolunteerTimeSlot/Create

		public ActionResult Create()
		{
			return View("Create", MakeEditDataFromVolunteerTimeSlot(new VolunteerTimeSlot()));
		}

		//
		// POST: /VolunteerTimeSlot/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var vts = new VolunteerTimeSlot();
			//TODO: all these parses might fail. fix it
			var timeslot =
				_repository.GetTimeSlotById(int.Parse(collection["VolunteerTimeSlot.timeslot_id"]));
			if (timeslot != null)
			{
				vts.TimeSlot = timeslot;
				vts.is_video = collection["VolunteerTimeSlot.is_video"].Contains("true");
				_repository.AddVolunteerTimeSlot(vts);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Create", MakeEditDataFromVolunteerTimeSlot(vts));
		}
		//
		// GET: /VolunteerTimeSlot/Delete/5

		public ActionResult Delete(int id)
		{
			var vts = _repository.GetVolunteerTimeSlotById(id);
			if (vts == null)
			{
				return View("VolunteerTimeSlotNotFound");
			}
			_repository.DeleteVolunteerTimeSlot(vts);
			_repository.Save();
			return RedirectToAction("Index");
		}

		private VolunteerTimeSlotEditData MakeEditDataFromVolunteerTimeSlot(VolunteerTimeSlot volunteerTimeSlot)
		{
			var timeslots = _repository.GetAllTimeSlots().ToList();
			foreach (var vts in _repository.GetAllVolunteerTimeSlots())
			{
				timeslots.Remove(vts.TimeSlot);
			}
			return new VolunteerTimeSlotEditData
					{
						VolunteerTimeSlot = volunteerTimeSlot,
						Timeslots = new SelectList(timeslots, "id", "StringValue")
					};
		}
	}
}
