using System;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class MechManiaTeamController : Controller
	{
		private readonly IRepository _repository;

		public MechManiaTeamController()
			: this(new ConferencewareRepository())
		{
			// done
		}

		public MechManiaTeamController(IRepository repo)
		{
			_repository = repo;
		}
		//
		// GET: /MechmaniaTeam/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllMechManiaTeams());
		}
		//
		// GET: /MechmaniaTeam/Create

		public ActionResult Create()
		{
			return View("Create", MakeAdminEditDataFromTeam(new MechManiaTeam()));
		}


		//
		// POST: /MechmaniaTeam/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var mmt = new MechManiaTeam();
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(mmt, "MechManiaTeam", collection))
			{
				if (mmt.account_name == null)
				{
					mmt.account_name = "";
				}
				if (mmt.account_password == null)
				{
					mmt.account_password = "";
				}
				_repository.AddMechManiaTeam(mmt);
				_repository.Save();
				TempData["Message"] = "Team Created";
				return RedirectToAction("Index");
			}
			return View("Create", MakeAdminEditDataFromTeam(mmt));
		}

		//
		// GET: /MechmaniaTeam/Edit/5

		public ActionResult Edit(int id)
		{
			var mmt = _repository.GetMechManiaTeamById(id);
			if (mmt == null)
			{
				return View("MechManiaTeamNotFound");
			}
			return View("Edit", MakeAdminEditDataFromTeam(mmt));
		}

		//
		// POST: /MechmaniaTeam/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var mmt = _repository.GetMechManiaTeamById(id);
			if (mmt == null)
			{
				return View("MechManiaTeamNotFound");
			}
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(mmt, "MechManiaTeam", collection))
			{
				_repository.Save();

				TempData["Message"] = "Team Updated";

				return RedirectToAction("Index");
			}
			return View("Edit", MakeAdminEditDataFromTeam(mmt));
		}

		//
		// GET: /MechmaniaTeam/Delete/5

		public ActionResult Delete(int id)
		{
			var mmt = _repository.GetMechManiaTeamById(id);
			if (mmt == null)
			{
				return View("MechManiaTeamNotFound");
			}
			TempData["Message"] = String.Format("MechMania Team {0} deleted",
												mmt.team_name);
			_repository.DeleteMechManiaTeam(mmt);
			_repository.Save();
			return RedirectToAction("Index");
		}

		private MechManiaTeamAdminEditData MakeAdminEditDataFromTeam(MechManiaTeam mechManiaTeam)
		{
			return new MechManiaTeamAdminEditData
					{
						MechManiaTeam = mechManiaTeam,
						Attendees = new SelectList(_repository.GetAllAttendees(), "person_id", "People.name")
					};
		}
	}
}
