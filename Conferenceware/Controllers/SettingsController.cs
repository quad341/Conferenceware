using System.Drawing;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Localization;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class SettingsController : Controller
	{
		//
		// GET: /Settings/

		public ActionResult Index()
		{
			return View("Index",
						SettingsData.Default);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(FormCollection collection)
		{
			SettingsData sd = SettingsData.Default;
			ProcessFiles(sd);
			// This will try to update all the fields in the model based on the form collection
			// due to files, we can't just have this nievely try all
			if (TryUpdateModel(sd,
							   new[]
			                   	{
			                   		"EmailFrom",
			                   		"FrontpageTitle",
			                   		"FrontpageContent",
			                   		"EventRegistrationConfirmationSubjectFormat",
			                   		"EventRegistrationConfirmationBodyFormat",
                                    "RegistrationSubject",
                                    "RegistrationMessage",
			                   		"SmtpHostname",
			                   		"SmtpPort",
			                   		"SmtpNeedsAuthentication",
			                   		"SmtpAuthenticationUserName",
			                   		"SmtpAuthenticationPassword",
									"MaxAttendees",
									"AttendeeRegistrationAutoCloseDateTime",
									"MaxVolunteers",
									"VolunteerRegistrationAutoCloseDateTime",
									"MaxMechManiaTeams",
									"MechManiaRegistrationAutoCloseDateTime",
									"StartDate",
									"EndDate",
									"Annum",
									"ShowEvents",
									"ShowSpeakers",
									"DisableLinkLocationCheck",
									"AllowTimeSlotsBeforeStart",
									"AllowTimeSlotsAfterEnd"
			                   	},
							   collection) && VerifyDatesMakeSense(sd, ModelState))
			{
				
				try
				{
					sd.Save(
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
			return View("Index", sd);
		}
		/// <summary>
		/// Checks to make sure that the conference ends after all the other dates
		/// </summary>
		/// <param name="sd">The settings data to verify</param>
		/// <param name="modelState">The model state to use for logging errors</param>
		/// <returns>Whether or not the settings data was valid</returns>
		private static bool VerifyDatesMakeSense(SettingsData sd, ModelStateDictionary modelState)
		{
			var success = true;
			if (sd.EndDate <= sd.StartDate)
			{
				modelState.AddModelError("StartDate",
				                         ControllerStrings.
				                         	SettingsController_Error_StartMustOccurBeforeEnd);
				success = false;
			}
			
			if (sd.AttendeeRegistrationAutoCloseDateTime >= sd.EndDate)
			{
				modelState.AddModelError("AttendeeRegistrationAutoCloseDateTime",
				                         ControllerStrings.
				                         	SettingsController_Error_RegistrationMustOccurBeforeEnd);
				success = false;
			}

			if (sd.VolunteerRegistrationAutoCloseDateTime >= sd.EndDate)
			{
				modelState.AddModelError("VolunteerRegistrationAutoCloseDateTime",
				                         ControllerStrings.
				                         	SettingsController_Error_RegistrationMustOccurBeforeEnd);
				success = false;
			}

			if (sd.MechManiaRegistrationAutoCloseDateTime >= sd.EndDate)
			{
				modelState.AddModelError("MechManiaRegistrationAutoCloseDateTime",
				                         ControllerStrings.
				                         	SettingsController_Error_RegistrationMustOccurBeforeEnd);
				success = false;
			}
			return success;
		}
		/// <summary>
		/// Iterates throught the Request.Files and adds them to the 
		/// provides settings data per which file it was
		/// </summary>
		/// <param name="sd">The settings data to put the files into</param>
		private void ProcessFiles(SettingsData sd)
		{
			foreach (string file in Request.Files)
			{
				HttpPostedFileBase hpf = Request.Files[file];
				if (hpf.ContentLength == 0)
					continue;
				if (hpf.ContentType != "image/png" && hpf.ContentType != "image/x-png")
				{
					ModelState.AddModelError(file,
					                         ControllerStrings.
					                         	SettingsController_Error_OnlyPNGAllowed);
					continue;
				}
				var fileObj = new Bitmap(hpf.InputStream);
				switch (file)
				{
					case "AttendeeBadgeBackground":
						sd.AttendeeBadgeBackground = fileObj;
						break;
					case "MechmaniaBadgeBackground":
						sd.MechmaniaBadgeBackground = fileObj;
						break;
					case "SpeakerBadgeBackground":
						sd.SpeakerBadgeBackground = fileObj;
						break;
					case "SponsorBadgeBackground":
						sd.SponsorBadgeBackground = fileObj;
						break;
					case "StaffBadgeBackground":
						sd.StaffBadgeBackground = fileObj;
						break;
					case "VolunteerBadgeBackground":
						sd.VolunteerBadgeBackground = fileObj;
						break;
				}
			}
		}

		public ActionResult GetImage(string filename)
		{
			SettingsData sd = SettingsData.Default;
			Bitmap img = null;
			switch (filename)
			{
				case "AttendeeBadgeBackground":
					img = sd.AttendeeBadgeBackground;
					break;
				case "MechmaniaBadgeBackground":
					img = sd.MechmaniaBadgeBackground;
					break;
				case "SpeakerBadgeBackground":
					img = sd.SpeakerBadgeBackground;
					break;
				case "SponsorBadgeBackground":
					img = sd.SponsorBadgeBackground;
					break;
				case "StaffBadgeBackground":
					img = sd.StaffBadgeBackground;
					break;
				case "VolunteerBadgeBackground":
					img = sd.VolunteerBadgeBackground;
					break;
			}
			return new PngResult(img);
		}
	}
}
