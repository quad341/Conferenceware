using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		[OutputCache(Duration = 3600, VaryByParam = "none", VaryByCustom = "settings")
		]
		public ActionResult Index()
		{
			SettingsData sd = SettingsData.Default;
			var frontPageSettings =
				new FrontpageSettings
					{
						Title = sd.FrontpageTitle,
						Content = sd.FrontpageContent
					};
			return View("Index", frontPageSettings);
		}

		[Authorize]
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