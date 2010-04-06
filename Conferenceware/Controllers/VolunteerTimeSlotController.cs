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

        //
        // POST: /VolunteerTimeSlot/Schedule

        [HttpPost]
        public ActionResult Schedule(FormCollection collection)
        {
            //TODO the parse calls might fail
            var volunteerId = int.Parse(collection["Volunteer"]);
            var timeslotId = int.Parse(collection["VolunteerTs.timeslot_id"]);

            var volunteer = _repository.GetVolunteerById(volunteerId);
            if(volunteer == null)
            {
                //TODO actually make it return an error
                return RedirectToAction("Index");
            }

            var vvts =
                volunteer.VolunteersVolunteerTimeSlots.SingleOrDefault(
                    x => (x.Volunteer.person_id == volunteerId) && (x.volunteer_timeslot_id == timeslotId));

            if (vvts != null)
            {
                vvts.is_confirmed = true;
                vvts.is_scheduled = true;
                _repository.Save();
                //TODO maybe show some confirmation msg
                return RedirectToAction("Index");
            }
            
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

            var volunteers = vts.VolunteersVolunteerTimeSlots.Select(x => x.Volunteer);
            if(vts.is_video)
            {
                volunteers = volunteers.Where(x => x.is_video_trained);
            }

            var vtsdat = new VolunteerTimeSlotScheduleData
                             {
                                 Volunteers = new SelectList(volunteers, "person_id", "People.name"),
                                 VolunteerTs = vts
                             };

            return View("Schedule", vtsdat);
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
