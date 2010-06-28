using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
    public class SchedulingController : Controller
    {
    	private readonly IRepository _repository;

		public SchedulingController() : this(new ConferencewareRepository())
		{
			// nothing to do
		}

		public SchedulingController(IRepository repo)
		{
			_repository = repo;
		}

        //
        // GET: /Scheduling/

        public ActionResult Index()
        {
            return View("Index");
        }

		public ActionResult EmailScheduleToVolunteers()
		{
			// TODO Implement
			return View("EmailScheduleToVolunteers");
		}

		public ActionResult PreviewRegularEmail()
		{
			var vol =
				_repository.GetAllVolunteers().Where(x => x.NeedsVideoTraining == false).
					SingleOrDefault();
			var message = "";
			if (vol == null)
			{
				TempData["Message"] = "No regular volunteers found";//TODO: localize
			}
			else
			{
				message = GetRegularMessageForVolunteer(vol);
			}
			return View("PreviewEmail", message);
		}

		public ActionResult PreviewVideoEmail()
		{
			var vol =
				_repository.GetAllVolunteers().Where(x => x.NeedsVideoTraining).
					SingleOrDefault();
			var message = "";
			if (vol == null)
			{
				TempData["Message"] = "No video volunteers found";//TODO: localize
			}
			else
			{
				message = GetVideoMessageForVolunteer(vol);
			}
			return View("PreviewEmail", message);
		}
		//TODO: make scheduling interface for volunteers and events

		private String GetMessageForVolunteer(Volunteer vol)
		{
			if (vol.NeedsVideoTraining)
			{
				return GetVideoMessageForVolunteer(vol);
			}
			return GetRegularMessageForVolunteer(vol);
		}
    }
}
