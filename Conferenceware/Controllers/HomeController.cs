using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		[OutputCache(Duration = 3600, VaryByParam = "none")]
		public ActionResult Index()
		{
			var frontPageSettings =
				new FrontpageSettings
					{
						Title = SettingsData.FromCurrent(Server.MapPath(SettingsData.RESOURCE_FILE_NAME)).FrontpageTitle,
						Content = SettingsData.FromCurrent(Server.MapPath(SettingsData.RESOURCE_FILE_NAME)).FrontpageContent
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
