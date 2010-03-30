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
							SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR));
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(SettingsData settingsData)
		{
			if (ModelState.IsValid)
			{
				try
				{
					settingsData.Save(
						SettingsData.RESOURCE_FILE_DIR + "\\" +
						SettingsData.RESOURCE_FILE_NAME +
						SettingsData.RESOURCE_FILE_EXT);
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