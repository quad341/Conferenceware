using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class BadgeController : Controller
	{
		private readonly IRepository _repository;
		private readonly SettingsData _sd;

		public BadgeController()
			: this(new ConferencewareRepository())
		{
			// all good
		}

		public BadgeController(IRepository repository)
		{
			_repository = repository;
			_sd = SettingsData.Default;
		}

		//
		// GET: /Badge/
		//
		public ActionResult Index()
		{
			return View("Index");
		}

		//
		// GET: /Badge/AttendeeBadges
		//
		public ActionResult AttendeeBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllAttendees().Select(x => x.People),
				_sd.AttendeeBadgeBackground,
				"AttendeeBadges.pdf");
		}

		//
		// GET: /Badge/MechmaniaBadges
		//
		public ActionResult MechmaniaBadges()
		{
			var mmpeople = new List<People>();
			foreach (MechManiaTeam mmt in _repository.GetAllMechManiaTeams())
			{
				mmpeople.Add(mmt.Attendee.People);
				mmpeople.Add(mmt.Attendee1.People);
				mmpeople.Add(mmt.Attendee2.People);
			}
			return new BadgePdfResult(
				mmpeople,
				_sd.MechmaniaBadgeBackground,
				"MechmaniaBadges.pdf");
		}

		//
		// GET: /Badge/SpeakerBadges
		//
		public ActionResult SpeakerBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllSpeakers().Select(x => x.People),
				_sd.SpeakerBadgeBackground,
				"SpeakerBadges.pdf");
		}

		//
		// GET: /Badge/SponsorBadges
		//
		public ActionResult SponsorBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllCompanyPersons().Select(x => x.People),
				_sd.SponsorBadgeBackground,
				"SponsorBadges.pdf");
		}

		//
		// GET: /Badges/StaffBadges
		//
		public ActionResult StaffBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllStaffMembers().Select(x => x.People),
				_sd.StaffBadgeBackground,
				"StaffBadges.pdf");
		}

		//
		// GET: /Badges/Volunteer
		//
		public ActionResult VolunteerBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllVolunteers().Select(x => x.People),
				_sd.VolunteerBadgeBackground,
				"VolunteerBadges.pdf");
		}
	}
}