using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class StaffMemberController : Controller
	{
		private readonly IRepository _repository;

		public StaffMemberController()
			: this(new ConferencewareRepository())
		{
			// done
		}

		public StaffMemberController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /StaffMember/

		public ActionResult Index()
		{
			return View();
		}

		//
		// GET: /StaffMember/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /StaffMember/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /StaffMember/Create

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
		// GET: /StaffMember/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /StaffMember/Edit/5

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
		// GET: /StaffMember/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /StaffMember/Delete/5

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
