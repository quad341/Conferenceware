using System.Web.Mvc;
using System.Linq;
using System.Net.Mail;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class MechmaniaRegistrationController : Controller
	{
		/// <summary>
		/// Repository to interact with the database
		/// </summary>

		public MechmaniaRegistrationController()
			: this(new ConferencewareRepository())
		{
		}
		public MechmaniaRegistrationController(IRepository repo)
		{
			_repository = repo;
		}
		private readonly IRepository _repository;
		//
		// GET: /MechmaniaRegistration/

		public ActionResult Index()
		{
			return View("Index", new MechmaniaTeamEditData());
		}

		//
		// POST: /MechmaniaRegistration/

		[HttpPost]
		public ActionResult Index(MechmaniaTeamEditData mmted)//FormCollection collection)
		{
			var att1 = _repository.GetAllAttendees().SingleOrDefault(x => x.People.email == mmted.member_email_1);
			if (att1 == null)
			{
				ModelState.AddModelError("member_email_1", "Email not found; did you register?");
			}
			var att2 = _repository.GetAllAttendees().SingleOrDefault(x => x.People.email == mmted.member_email_2);
			if (att2 == null)
			{
				ModelState.AddModelError("member_email_2", "Email not found; did you register?");
			}
			var att3 = _repository.GetAllAttendees().SingleOrDefault(x => x.People.email == mmted.member_email_3);
			if (att3 == null)
			{
				ModelState.AddModelError("member_email_3", "Email not found; did you register?");
			}
			if (ModelState.IsValid)
			{
				var mmt = new MechManiaTeam
							{
								team_name = mmted.team_name,
								member1_id = att1.person_id,
								member2_id = att2.person_id,
								member3_id = att3.person_id,
								account_name = "",
								account_password = ""
							};
				_repository.AddMechManiaTeam(mmt);
				_repository.Save();
				return RedirectToAction("Success");
			}
			return View("Index", mmted);
		}
		public ActionResult Success()
		{
			return View("Success");
		}
	}
}
