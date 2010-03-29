using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class PageController : Controller
	{
		private readonly IRepository _repository;

		public PageController()
			: this(new ConferencewareRepository())
		{
			// done
		}

		public PageController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /Page/Title

		public ActionResult View(string name)
		{
			return View("View", _repository.GetPageByTitle(name));
		}

	}
}
