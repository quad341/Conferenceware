using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conferenceware.Controllers
{
    public class AttendeeController : Controller
    {
        //
        // GET: /Attendee/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Attendee/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Attendee/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Attendee/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Attendee/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Attendee/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
