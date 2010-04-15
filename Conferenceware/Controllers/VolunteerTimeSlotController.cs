using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
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

		//
		// POST: /VolunteerTimeSlot/Schedule

		[HttpPost]
		public ActionResult Schedule(FormCollection collection)
		{
			//TODO the parse calls might fail
			int vvtsid;
			if (!int.TryParse(collection["VolunteersVolunteerTimeSlot"], out vvtsid))
			{
				ModelState.AddModelError("VolunteersVolunteerTimeSlot", "Invalid Selection");
			}
			var vvts = _repository.GetVolunteersVolunteerTimeSlotById(vvtsid);
			if (vvts == null)
			{
				TempData["Message"] = "Error finding volunteer time slot link";
				return RedirectToAction("Index");
			}

			if (ModelState.IsValid)
			{
				vvts.is_confirmed = true;
				vvts.is_scheduled = true;
				_repository.Save();
				TempData["Message"] = "Volunteer Scheduled";
				return RedirectToAction("Index");
			}
			// not redirecting back; something went wrong so our data is lost
			TempData["Message"] = "Invalid selection";
			return RedirectToAction("Index");
		}

		//
		// GET: /VolunteerTimeSlot/Schedule/5

		public ActionResult Schedule(int id)
		{
			var vts = _repository.GetVolunteerTimeSlotById(id);
			if (vts == null)
			{
				return View("VolunteerTimeSlotNotFound");
			}

			var prunedVvts =
				vts.VolunteersVolunteerTimeSlots.Where(
					x => !vts.ConfirmedVolunteers.Contains(x.Volunteer));

			var vtsdat = new VolunteerTimeSlotScheduleData
							{
								Volunteers =
									new SelectList(prunedVvts,
												   "id",
												   "Volunteer.People.name"),
								VolunteerTs = vts
							};

			return View("Schedule", vtsdat);
		}

		public ActionResult UnSchedule(int id)
		{
			var vvts = _repository.GetVolunteersVolunteerTimeSlotById(id);
			if (vvts == null)
			{
				TempData["Message"] = "Link not found";
			}
			else
			{
				vvts.is_confirmed = false;
				vvts.is_scheduled = false;
				_repository.Save();
				TempData["Message"] = "Volunteer Unscheduled";
			}
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
