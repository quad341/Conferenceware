using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class TimeSlotController : Controller
    {
        /// <summary>
		/// Repository to interact with database
		/// </summary>
    	private readonly IRepository _repository;

		public TimeSlotController() : this(new ConferencewareRepository())
		{
			// nothing more to do
		}

    	public TimeSlotController(IRepository repo)
		{
			_repository = repo;
		}


        //
        // GET: /TimeSlot/

        public ActionResult Index()
        {
            return View("Index", _repository.GetAllTimeSlots());
        }

        //
        // GET: /TimeSlot/Create

        public ActionResult Create()
        {
            return View("Create", new Location());
        } 

        //
        // POST: /TimeSlot/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            TimeSlot timeSlotToCreate = new TimeSlot();

            TryUpdateModel(timeSlotToCreate);

            if (ModelState.IsValid)
            {
                _repository.AddTimeSlot(timeSlotToCreate);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View("Create", timeSlotToCreate);
        }

        //
        // GET: /TimeSlot/Edit/5
 
        public ActionResult Edit(int id)
        {
            TimeSlot ts = _repository.GetTimeSlotById(id);
            if (ts == null)
            {
                View("TimeSlotNotFound");
            }
            return View("Edit", ts);
        }

        //
        // POST: /TimeSlot/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            TimeSlot ts = _repository.GetTimeSlotById(id);
            try
            {
                UpdateModel(ts);
                _repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit", ts);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TimeSlot ts = _repository.GetTimeSlotById(id);
            if (ts == null)
            {
                return View("TimeSlotNotFound");
            }

            _repository.DeleteTimeSlot(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
