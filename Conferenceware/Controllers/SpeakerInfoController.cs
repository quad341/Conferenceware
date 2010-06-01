using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
    public class SpeakerInfoController : Controller
    {
    	private readonly IRepository _repository;

		public SpeakerInfoController() : this(new ConferencewareRepository())
		{
			// done
		}

		public SpeakerInfoController(IRepository repo)
		{
			_repository = repo;
		}
        //
        // GET: /SpeakerInfo/

        public ActionResult Index()
        {
			if (!SettingsData.Default.ShowSpeakers)
			{
				return View("InformationUnavailable");
			}
            return View("Index", _repository.GetAllSpeakers());
        }

        //
        // GET: /SpeakerInfo/Display/5

        public ActionResult Display(int id)
        {
			if (!SettingsData.Default.ShowSpeakers)
			{
				return View("InformationUnavailable");
			}
        	var speaker = _repository.GetSpeakerById(id);
			return speaker == null ? View("SpeakerNotFound") : View("Display", speaker);
        }

    }
}
