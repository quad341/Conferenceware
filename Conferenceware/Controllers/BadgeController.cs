using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
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
			_sd = SettingsData.FromCurrent(
				SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
		}
		//
		// GET: /Badge/

		public ActionResult Index()
		{
			return View("Index");
		}

		public ActionResult AttendeeBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllAttendees().Select(x => x.People),
				_sd.AttendeeBadgeBackground,
				"AttendeeBadges.pdf");
		}

		public ActionResult SponsorBadges()
		{
			return new BadgePdfResult(
				_repository.GetAllCompanyPersons().Select(x => x.People),
				_sd.SponsorBadgeBackground,
				"SponsorBadges.pdf");
		}
	}
}
