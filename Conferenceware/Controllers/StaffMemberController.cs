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
			return View("Index", _repository.GetAllStaffMembers());
		}

		//
		// GET: /StaffMember/Create

		public ActionResult Create()
		{
			return View("Create", new StaffMember());
		}

		//
		// POST: /StaffMember/Create

		[HttpPost]
		public ActionResult Create(StaffMember sm)
		{
			if (ModelState.IsValid)
			{
				_repository.AddStaffMember(sm);
				_repository.Save();
				TempData["Message"] = "Staff Member created";
				return RedirectToAction("Index");
			}
			return View("Create", sm);
		}

		//
		// GET: /StaffMember/Edit/5

		public ActionResult Edit(int id)
		{
			var sm = _repository.GetStaffMemberById(id);
			if (sm == null)
			{
				return View("StaffMemberNotFound");
			}
			return View("Edit", sm);
		}

		//
		// POST: /StaffMember/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var sm = _repository.GetStaffMemberById(id);
			if (sm == null)
			{
				return View("StaffMemberNotFound");
			}
			if (TryUpdateModel(sm))
			{
				_repository.Save();
				TempData["Message"] = "Staff Member updated";
				return RedirectToAction("Index");
			}
			return View("Edit", sm);
		}

		//
		// GET: /StaffMember/Delete/5

		public ActionResult Delete(int id)
		{
			var sm = _repository.GetStaffMemberById(id);
			if (sm == null)
			{
				return View("StaffMemberNotFound");
			}
			_repository.DeleteStaffMember(sm);
			_repository.Save();
			TempData["Message"] = "Staff Member deleted";
			return RedirectToAction("Index");
		}
	}
}
