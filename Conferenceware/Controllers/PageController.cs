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

		public ActionResult Display(string name)
		{
			Page page = _repository.GetPageByTitle(name);
			if (page == null)
			{
				return Display("PageNotFound");
			}
			return View("Display", page);
		}
	}
}