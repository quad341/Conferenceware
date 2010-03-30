using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Conferenceware.Models
{
	/// <summary>
	/// Model for holding the data to store in the Settings .resx
	/// </summary>
	public class SettingsData
	{
		/// <summary>
		/// The file the the updated settings will come from
		/// </summary>
		public const string RESOURCE_FILE_NAME = "CurrentSettings";

		/// <summary>
		/// The directory from the program base to store the settings file
		/// </summary>
		public const string RESOURCE_FILE_DIR = "App_Data";

		private static readonly string _baseDir = AppDomain.CurrentDomain.BaseDirectory;

		/// <summary>
		/// The file extention to use for the file
		/// </summary>
		public const string RESOURCE_FILE_EXT = ".resources";
		/// <summary>
		/// The Front page title string
		/// </summary>
		[Required]
		[StringLength(100)]
		[DisplayName("Front page title")]
		public string FrontpageTitle
		{
			get;
			set;
		}

		/// <summary>
		/// The Front page content
		/// </summary>
		[Required]
		[DisplayName("Front page content (HTML)")]
		public string FrontpageContent
		{
			get;
			set;
		}

		/// <summary>
		/// The from email address for sending mail
		/// </summary>
		[Required]
		[RegularExpression(@"[A-Za-z0-9_%+-]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("From address for email")]
		public string EmailFrom
		{
			get;
			set;
		}

		/// <summary>
		/// Format string for the body of event registration email confirmations
		/// </summary>
		[Required]
		[DisplayName("Format string for body of email for event registration confirmations. Use {0} for event name, {1} for event time and {2} for event location; all are required")]
		[RegularExpression(@".*({0}.*{1}.*{2}|{0}.*{2}.*{1}|{1}.*{0}.*{2}|{1}.*{2}.*{0}|{2}.*{0}.*{1}|{2}.*{1}.*{0}).*", ErrorMessage = "Must use {0},{1},{2} for event name, event time, and event location respectively")]
		public string EventRegistrationConfirmationBodyFormat
		{
			get;
			set;
		}

		/// <summary>
		/// Format string for the subject of event registration email confirmations
		/// </summary>
		[Required]
		[StringLength(100)]
		[DisplayName("Format string for subject of email for event registration confirmations. Use {0} for event name (required)")]
		[RegularExpression(@".*{0}.*", ErrorMessage = "Must use {0} for event name")]
		public string EventRegistrationConfirmationSubjectFormat
		{
			get;
			set;
		}

		#region Badge Backgrounds
		// Images can't exactly be validated since they are uploaded though Request.Files
		public Bitmap AttendeeBadgeBackground
		{
			get;
			set;
		}

		public Bitmap MechmaniaBadgeBackground
		{
			get;
			set;
		}

		public Bitmap SpeakerBadgeBackground
		{
			get;
			set;
		}

		public Bitmap SponsorBadgeBackground
		{
			get;
			set;
		}

		public Bitmap StaffBadgeBackground
		{
			get;
			set;
		}

		public Bitmap VolunteerBadgeBackground
		{
			get;
			set;
		}
		#endregion

		public static SettingsData FromCurrent(string fileBase, string dirName)
		{
			ResourceManager rm = null;
			var sd = new SettingsData
						{
							FrontpageContent = Settings.FrontpageContent,
							FrontpageTitle = Settings.FrontpageTitle,
							EmailFrom = Settings.EmailFrom,
							EventRegistrationConfirmationSubjectFormat =
								Settings.EventRegistrationConfirmationSubjectFormat,
							EventRegistrationConfirmationBodyFormat =
								Settings.EventRegistrationConfirmationBodyFormat,
							AttendeeBadgeBackground = Settings.AttendeeBadgeBackground,
							MechmaniaBadgeBackground = Settings.MechmaniaBadgeBackground,
							SpeakerBadgeBackground = Settings.SpeakerBadgeBackground,
							SponsorBadgeBackground = Settings.SponsorBadgeBackground,
							StaffBadgeBackground = Settings.StaffBadgeBackground,
							VolunteerBadgeBackground = Settings.VolunteerBadgeBackground
						};
			try
			{
				rm = ResourceManager.CreateFileBasedResourceManager(fileBase, _baseDir + dirName, null);
				sd.FrontpageContent = rm.GetString("FrontpageContent");
				sd.FrontpageTitle = rm.GetString("FrontpageTitle");
				sd.EmailFrom = rm.GetString("EmailFrom");
				sd.EventRegistrationConfirmationBodyFormat =
					rm.GetString("EventRegistrationConfirmationBodyFormat");
				sd.EventRegistrationConfirmationSubjectFormat =
					rm.GetString("EventRegistrationConfirmationSubjectFormat");
				sd.AttendeeBadgeBackground =
					rm.GetObject("AttendeeBadgeBackground") as Bitmap;
				sd.MechmaniaBadgeBackground =
					rm.GetObject("MechmaniaBadgeBackground") as Bitmap;
				sd.SpeakerBadgeBackground =
					rm.GetObject("SpeakerBadgeBackground") as Bitmap;
				sd.SponsorBadgeBackground =
					rm.GetObject("SponsorBadgeBackground") as Bitmap;
				sd.StaffBadgeBackground =
					rm.GetObject("StaffBadgeBackground") as Bitmap;
				sd.VolunteerBadgeBackground =
					rm.GetObject("VolunteerBadgeBackground") as Bitmap;
				rm.ReleaseAllResources();
			}
			catch
			{
				if (rm != null)
				{
					rm.ReleaseAllResources();
				}
				// something went wrong; probably the file doesn't exist yet
			}
			return sd;
		}

		public void Save(string path)
		{
			var writer = new ResourceWriter(_baseDir + path);
			writer.AddResource("FrontpageContent", FrontpageContent);
			writer.AddResource("FrontpageTitle", FrontpageTitle);
			writer.AddResource("EmailFrom", EmailFrom);
			writer.AddResource("EventRegistrationConfirmationBodyFormat", EventRegistrationConfirmationBodyFormat);
			writer.AddResource("EventRegistrationConfirmationSubjectFormat", EventRegistrationConfirmationSubjectFormat);
			writer.AddResource("AttendeeBadgeBackground", AttendeeBadgeBackground);
			writer.AddResource("MechmaniaBadgeBackground", MechmaniaBadgeBackground);
			writer.AddResource("SpeakerBadgeBackground", SpeakerBadgeBackground);
			writer.AddResource("SponsorBadgeBackground", SponsorBadgeBackground);
			writer.AddResource("StaffBadgeBackground", StaffBadgeBackground);
			writer.AddResource("VolunteerBadgeBackground", VolunteerBadgeBackground);
			writer.Generate();
			writer.Close();
		}
	}
}