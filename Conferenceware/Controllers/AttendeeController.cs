using System;
using System.Collections.Generic;
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
            return View(_repository.GetAllAttendees());
        }

        //
        // GET: /Speaker/Create

        public ActionResult Create()
        {
            return View(new AttendeeEditData());
        }

        //
        // POST: /Speaker/Create

        [HttpPost]
        public ActionResult Create(Attendee newAttendee)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAttendee(newAttendee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(newAttendee);
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
            return View(att);
        }

        //
        // POST: /Speaker/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var att = _repository.GetAttendeeById(id);
            try
            {
                UpdateModel(att);
                _repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(att);
            }
        }

        public ActionResult Delete(int id)
        {
            var att = _repository.GetAttendeeById(id);
            if (att == null)
            {
                return View("AttendeeNotFound");
            }
            _repository.DeleteAttendee(att);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
