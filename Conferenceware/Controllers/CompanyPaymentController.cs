using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conferenceware.Controllers
{
    public class CompanyPaymentController : Controller
    {
        //
        // GET: /CompanyPayment/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CompanyPayment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CompanyPayment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CompanyPayment/Create

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
        // GET: /CompanyPayment/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CompanyPayment/Edit/5

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
        // GET: /CompanyPayment/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CompanyPayment/Delete/5

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
