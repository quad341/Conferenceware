using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IRepository _repository;

        public ScheduleController()
            : this(new ConferencewareRepository())
        {
            //nothing to do here
        }

        public ScheduleController(IRepository repo)
        {
            _repository = repo;
        }

        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            var events = _repository.GetAllEvents();
            var timeslots = _repository.GetAllTimeSlots();
            return View("Index", events.OrderBy(e => e.TimeSlot.start_time));
        }

        public ActionResult Details(int id)
        {
            return View(_repository.GetEventById(id));
        }
    }
}
