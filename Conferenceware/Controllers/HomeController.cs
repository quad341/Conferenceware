using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var frontPageSettings =
				new FrontpageSettings
					{
						Title = Settings.FrontpageTitle,
						Content = Settings.FrontpageContent
					};
			return View("Index", frontPageSettings);
		}

		public ActionResult Admin()
		{
			return View("Admin");
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
