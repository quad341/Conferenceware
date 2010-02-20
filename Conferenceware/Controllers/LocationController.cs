using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class LocationController : Controller
    {
		/// <summary>
		/// Repository to interact with database
		/// </summary>
    	private readonly IRepository _repository;

		public LocationController() : this(new ConferencewareRepository())
		{
			// nothing more to do
		}

    	public LocationController(IRepository repo)
		{
			_repository = repo;
		}
        //
        // GET: /Location/

        public ActionResult Index()
        {
            return View("Index",_repository.GetAllLocations());
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View("Create",new Location());
        } 

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(Location locationToCreate)
        {
			if (ModelState.IsValid)
			{
				_repository.AddLocation(locationToCreate);
				_repository.Save();
				return RedirectToAction("Index");
			}
        	return View("Create",locationToCreate);
        }

        //
        // GET: /Location/Edit/5
 
        public ActionResult Edit(int id)
        {
        	var loc = _repository.GetLocationById(id);
			if(loc==null)
			{
				View("LocationNotFound");
			}
            return View("Edit",loc);
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
				_repository.Save();
				return RedirectToAction("Index");
			}
			catch
			{
				return View("Edit",loc);
			}
        }

		public ActionResult Delete(int id)
		{
			var loc = _repository.GetLocationById(id);
			if(loc == null)
			{
				return View("LocationNotFound");
			}
			_repository.DeleteLocation(loc);
			_repository.Save();
			return RedirectToAction("Index");
		}
    }
}
