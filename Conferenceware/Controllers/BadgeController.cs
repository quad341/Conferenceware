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
        private List<People> mmpeople = new List<People>();
        private List<People> attendees = new List<People>();
        private List<People> speakers = new List<People>();
        private List<People> sponsors = new List<People>();
        private List<People> staff = new List<People>();
        private List<People> volunteers = new List<People>();

		public BadgeController()
			: this(new ConferencewareRepository())
		{
			// all good
		}

		public BadgeController(IRepository repository)
		{
			_repository = repository;
			_sd = SettingsData.Default;
            foreach (MechManiaTeam mmt in _repository.GetAllMechManiaTeams())
            {
                mmpeople.Add(mmt.Attendee.People);
                mmpeople.Add(mmt.Attendee1.People);
                mmpeople.Add(mmt.Attendee2.People);
            }

            speakers = _repository.GetAllSpeakers().Select(x => x.People).ToList();
            volunteers = _repository.GetAllVolunteers().Select(x => x.People).ToList();
            staff = _repository.GetAllStaffMembers().Select(x => x.People).ToList();
            sponsors = _repository.GetAllCompanyPersons().Select(x => x.People).ToList();
            attendees = _repository.GetAllAttendees().Select(x => x.People).Where(x => (x.Attendee.food_choice_id > 3) && !speakers.Contains(x) && !volunteers.Contains(x) && !mmpeople.Contains(x) && !staff.Contains(x) && !speakers.Contains(x)).ToList();


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
				attendees,
				_sd.AttendeeBadgeBackground,
				"AttendeeBadges.pdf");
		}

		//
		// GET: /Badge/MechmaniaBadges
		//
		public ActionResult MechmaniaBadges()
		{
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
				speakers,
				_sd.SpeakerBadgeBackground,
				"SpeakerBadges.pdf");
		}

		//
		// GET: /Badge/SponsorBadges
		//
		public ActionResult SponsorBadges()
		{
			return new BadgePdfResult(
				sponsors,
				_sd.SponsorBadgeBackground,
				"SponsorBadges.pdf");
		}

		//
		// GET: /Badges/StaffBadges
		//
		public ActionResult StaffBadges()
		{
			return new BadgePdfResult(
				staff,
				_sd.StaffBadgeBackground,
				"StaffBadges.pdf");
		}

		//
		// GET: /Badges/Volunteer
		//
		public ActionResult VolunteerBadges()
		{
			return new BadgePdfResult(
				volunteers,
				_sd.VolunteerBadgeBackground,
				"VolunteerBadges.pdf");
		}
	}
}