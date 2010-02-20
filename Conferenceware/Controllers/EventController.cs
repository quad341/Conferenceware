using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class EventController : Controller
    {


/// <summary>
		/// Repository to interact with database
		/// </summary>
    	private readonly IRepository _repository;

		public EventController() : this(new ConferencewareRepository())
		{
			// nothing more to do
		}

    	public EventController(IRepository repo)
		{
			_repository = repo;
		}

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View("Create", new Event());
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var eventToCreate = new Event();

            TryUpdateModel(eventToCreate);

            if (ModelState.IsValid)
            {
                _repository.AddEvent(eventToCreate);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View("Create", eventToCreate);
        }

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View("Index", _repository.GetAllEvents());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id)
        {
            Event ev = _repository.GetEventById(id);
            if (ev == null)
            {
                View("EventNotFound");
            }
            return View("Details",ev);
        }

        //
        // GET: /Event/Edit/5
 
        public ActionResult Edit(int id)
        {
            Event ev = _repository.GetEventById(id);
            if (ev == null)
            {
                View("EventNotFound");
            }
            return View("Edit", ev);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Event ev = _repository.GetEventById(id);
            try
            {
                UpdateModel(ev);
                _repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit", ev);
            }
        }

        public ActionResult Delete(int id)
        {
            Event ev = _repository.GetEventById(id);
            if (ev == null)
            {
                return View("EventNotFound");
            }
            _repository.DeleteEvent(ev);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
