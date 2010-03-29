using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class SettingsController : Controller
	{
		//
		// GET: /Settings/

		public ActionResult Index()
		{
			return View("Index",
						SettingsData.FromCurrent(
							Server.MapPath(SettingsData.RESOURCE_FILE_NAME)));
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(SettingsData settingsData)
		{
			if (ModelState.IsValid)
			{
				try
				{
					settingsData.Save(Server.MapPath(SettingsData.RESOURCE_FILE_NAME));
					TempData["Message"] = "Settings saved";
				}
				catch
				{
					TempData["Message"] = "Unable to write file";
				}
			}
			else
			{
				TempData["Message"] =
					"Settings not saved. Correct the errors below and try again";
			}
			return View("Index", settingsData);
		}
	}
}