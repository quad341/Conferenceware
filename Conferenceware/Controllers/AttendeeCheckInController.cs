using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class AttendeeCheckInController : Controller
    {
    	private readonly IRepository _repository;

		public AttendeeCheckInController() : this(new ConferencewareRepository())
		{
			//all good
		}

		public AttendeeCheckInController(IRepository repo)
		{
			_repository = repo;
		}
        //
        // GET: /AttendeeCheckIn/

        public ActionResult Index()
        {
            return View("Index");
        }

		public ActionResult Search(string query)
		{
			var results =
				_repository.GetAllAttendees().Where(
					x => x.People.name.Contains(query) 
						|| x.People.email.Contains(query));
			return View("Search",
			            new AttendeeCheckInDisplayData
			            	{Attendees = results, Query = query});
		}

		public ActionResult CheckIn(int id, string query)
		{
			var attendee = _repository.GetAttendeeById(id);
			if (attendee != null)
			{
				attendee.checked_in = true;
				TempData["Message"] = attendee.People.name + " was checked in.";
			}
			return RedirectToAction("Search", new {query});
		}


		public ActionResult UnCheckIn(int id, string query)
		{
			var attendee = _repository.GetAttendeeById(id);
			if (attendee != null)
			{
				attendee.checked_in = false;
				TempData["Message"] = attendee.People.name + " was un-checked in.";
			}
			return RedirectToAction("Search", new {query});
		}
    }
}
