using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class VolunteerTimeSlotController : Controller
	{
		private readonly IRepository _repository;

		public VolunteerTimeSlotController()
			: this(new ConferencewareRepository())
		{
			// it's all good
		}

		public VolunteerTimeSlotController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /VolunteerTimeSlot/

		public ActionResult Index()
		{
			return View("Index");
		}

		//
		// GET: /VolunteerTimeSlot/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /VolunteerTimeSlot/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /VolunteerTimeSlot/Create

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
		// GET: /VolunteerTimeSlot/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /VolunteerTimeSlot/Edit/5

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
		// GET: /VolunteerTimeSlot/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /VolunteerTimeSlot/Delete/5

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
