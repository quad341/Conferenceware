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
            var schedule = _repository.GetAllEvents().OrderBy(ev => ev.TimeSlot).GroupBy(e => e.Location);
            return View("Index", schedule);
        }

        public ActionResult Details()
        {
            return View();
        }

    }
}
