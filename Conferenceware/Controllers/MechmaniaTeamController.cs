using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class MechmaniaTeamController : Controller
    {
        //
        // GET: /MechmaniaTeam/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MechmaniaTeam/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MechmaniaTeam/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MechmaniaTeam/Create

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
        // GET: /MechmaniaTeam/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MechmaniaTeam/Edit/5

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

        //
        // GET: /MechmaniaTeam/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MechmaniaTeam/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
