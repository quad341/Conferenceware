using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;
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
									"ShowEvents",
									"ShowSpeakers",
									"DisableLinkLocationCheck"
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

		private bool VerifyDatesMakeSense(SettingsData sd, ModelStateDictionary modelState)
		{
			var success = true;
			if (sd.EndDate <= sd.StartDate)
			{
				modelState.AddModelError("StartDate", "Start Date must occur before end date");
				success = false;
			}
			// TODO: make sure registration is closed before end date
			return success;
		}

		private void ProcessFiles(SettingsData sd)
		{
			foreach (string file in Request.Files)
			{
				HttpPostedFileBase hpf = Request.Files[file];
				if (hpf.ContentLength == 0)
					continue;
				if (hpf.ContentType != "image/png" && hpf.ContentType != "image/x-png")
				{
					ModelState.AddModelError(file, "Only PNG images are allowed");
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
