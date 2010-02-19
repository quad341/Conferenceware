using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class LocationController : Controller
    {
    	private readonly IRepository _repository;

		public LocationController(IRepository repo)
		{
			_repository = repo;
		}

		public LocationController () : this(new ConferencewareRepository())
		{
			// no other actions needed
		}

        //
        // GET: /Location/

        public ActionResult Index()
        {
            return View(_repository.GetAllLocations());
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View(new Location());
        } 

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
			var loc = new Location();
            try
            {
				UpdateModel(loc);
				_repository.AddLocation(loc);
                return RedirectToAction("Index");
            }
            catch
            {
				// add errors
                return View(loc);
            }
        }

        //
        // GET: /Location/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_repository.GetLocationById(id));
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
        	var loc = _repository.GetLocationById(id);
            try
            {
				UpdateModel(loc);
				_repository.AddLocation(loc);
				_repository.Save();
 
                return RedirectToAction("Index");
            }
            catch
            {
				// add errors
                return View(loc);
            }
        }

		public ActionResult Delete(int id)
		{
			try
			{
				_repository.DeleteLocation(id);
			}
			catch
			{
				// i guess it didn't work?
			}
			return RedirectToAction("Index");
		}
    }
}
