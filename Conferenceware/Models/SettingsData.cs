using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Resources;

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

		/// <summary>
		/// The file extention to use for the file
		/// </summary>
		public const string RESOURCE_FILE_EXT = ".resources";

		private static readonly string _baseDir =
			AppDomain.CurrentDomain.BaseDirectory;
		#region Frontpage
		/// <summary>
		/// The Front page title string
		/// </summary>
		[Required]
		[StringLength(100)]
		[DisplayName("Front page title")]
		public string FrontpageTitle { get; set; }

		/// <summary>
		/// The Front page content
		/// </summary>
		[Required]
		[DisplayName("Front page content (HTML)")]
		public string FrontpageContent { get; set; }

		#endregion

		#region EmailStrings
		/// <summary>
		/// The from email address for sending mail
		/// </summary>
		[Required]
		[RegularExpression(@"[A-Za-z0-9_%+-]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("From address for email")]
		public string EmailFrom { get; set; }

		/// <summary>
		/// Format string for the body of event registration email confirmations
		/// </summary>
		[Required]
		[DisplayName(
			"Format string for body of email for event registration confirmations. Use {0} for event name, {1} for event time and {2} for event location; all are required"
			)]
		[RegularExpression(
			@".*({0}.*{1}.*{2}|{0}.*{2}.*{1}|{1}.*{0}.*{2}|{1}.*{2}.*{0}|{2}.*{0}.*{1}|{2}.*{1}.*{0}).*"
			,
			ErrorMessage =
				"Must use {0},{1},{2} for event name, event time, and event location respectively"
			)]
		public string EventRegistrationConfirmationBodyFormat { get; set; }

		/// <summary>
		/// Format string for the subject of event registration email confirmations
		/// </summary>
		[Required]
		[StringLength(100)]
		[DisplayName(
			"Format string for subject of email for event registration confirmations. Use {0} for event name (required)"
			)]
		[RegularExpression(@".*{0}.*", ErrorMessage = "Must use {0} for event name")]
		public string EventRegistrationConfirmationSubjectFormat { get; set; }

		[Required]
		[StringLength(100)]
		[DisplayName("Registration Confirmation Email Subject")]
		public string RegistrationSubject { get; set; }

		[Required]
		[DisplayName(
			"Registration Message Email (use {name} for name and {role} for type (attendee, volunteer, etc.))"
			)]
		public string RegistrationMessage { get; set; }
		#endregion

		#region Badge Backgrounds

		// Images can't exactly be validated since they are uploaded though Request.Files
		[DisplayName("Attendee Badge Background Image (png)")]
		public Bitmap AttendeeBadgeBackground { get; set; }

		[DisplayName("Mechmania Badge Background Image (png)")]
		public Bitmap MechmaniaBadgeBackground { get; set; }

		[DisplayName("Speaker Badge Background Image (png)")]
		public Bitmap SpeakerBadgeBackground { get; set; }

		[DisplayName("Sponsor Badge Background Image (png)")]
		public Bitmap SponsorBadgeBackground { get; set; }

		[DisplayName("Staff Badge Background Image (png)")]
		public Bitmap StaffBadgeBackground { get; set; }

		[DisplayName("Volunteer Badge Background Image (png)")]
		public Bitmap VolunteerBadgeBackground { get; set; }

		#endregion

		#region SmtpSettings

		[DisplayName("SMTP server requires authentication?")]
		public bool SmtpNeedsAuthentication { get; set; }

		[DisplayName("Username for SMTP server")]
		public string SmtpAuthenticationUserName { get; set; }

		[DisplayName("Password for SMTP server")]
		public string SmtpAuthenticationPassword { get; set; }

		[Required]
		[DisplayName("SMTP server hostname")]
		public string SmtpHostname { get; set; }

		[Range(1, 65535)]
		[DisplayName("SMTP server port")]
		public int SmtpPort { get; set; }

		#endregion

		#region RegistrationSettings
		/// <summary>
		/// The maximum attendees allowed to register
		/// </summary>
		[Range(0,int.MaxValue)]
		[DisplayName("Maximum number of registered attendees (0 is no limit)")]
		public int MaxAttendees { get; set; }

		/// <summary>
		/// The date/time to automatically close attendee registration
		/// </summary>
		[Required]
		[DisplayName("Date/time to automatically close attendee registration")]
		public DateTime AttendeeRegistrationAutoCloseDateTime { get; set; }

		/// <summary>
		/// The maximum volunteers allowed to register
		/// </summary>
		[Range(0, int.MaxValue)]
		[DisplayName("Maximum number of registered volunteers (0 is no limit)")]
		public int MaxVolunteers { get; set; }

		/// <summary>
		/// The date/time to automatically close attendee registration
		/// </summary>
		[Required]
		[DisplayName("Date/time to automatically close volunteer registration")]
		public DateTime VolunteerRegistrationAutoCloseDateTime { get; set; }


		/// <summary>
		/// The maximum mechmania teams allowed to register
		/// </summary>
		[Range(0, int.MaxValue)]
		[DisplayName("Maximum number of registered MechMania Teams (0 is no limit)")]
		public int MaxMechManiaTeams { get; set; }

		/// <summary>
		/// The date/time to automatically close mechmania registration
		/// </summary>
		[Required]
		[DisplayName("Date/time to automatically close mechmania registration")]
		public DateTime MechManiaRegistrationAutoCloseDateTime { get; set; }
		#endregion

		#region SiteDisplayRelatedSettings
		/// <summary>
		/// The conference start date
		/// </summary>
		[Required]
		[DisplayName("The conference's start date")]
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The conference end date
		/// </summary>
		[Required]
		[DisplayName("The conference's end date")]
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Whether or not to publically display events
		/// </summary>
		[DisplayName("Show the events list publically?")]
		public bool ShowEvents { get; set; }

		/// <summary>
		/// Whether or not to publically display the speakers
		/// </summary>
		[DisplayName("Show the speakers list publically?")]
		public bool ShowSpeakers { get; set; }

		/// <summary>
		/// Whether or not to disable the location check for linked files for events
		/// 
		/// This can be useful especially if the server is sitting behind a load balancer
		///  or otherwise if its urls are not what one would need to access the files
		/// </summary>
		[DisplayName("Disable the location verification on linked files?")]
		public bool DisableLinkLocationCheck { get; set; }
		#endregion

		public static SettingsData Default
		{
			get
			{
				return SettingsData.FromCurrent(SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
			}
		}

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
			         		VolunteerBadgeBackground = Settings.VolunteerBadgeBackground,
			         		SmtpNeedsAuthentication = true,
			         		SmtpHostname = Settings.SmtpHostname,
			         		SmtpPort = int.Parse(Settings.SmtpPort),
			         		SmtpAuthenticationUserName = Settings.SmtpAuthenticationUserName,
			         		SmtpAuthenticationPassword = Settings.SmtpAuthenticationPassword,
			         		RegistrationSubject = Settings.RegistrationSubject,
			         		RegistrationMessage = Settings.RegistrationMessage,
			         		MaxAttendees = 0,
			         		AttendeeRegistrationAutoCloseDateTime = DateTime.Now,
			         		MaxVolunteers = 0,
			         		VolunteerRegistrationAutoCloseDateTime = DateTime.Now,
			         		MaxMechManiaTeams = 0,
			         		MechManiaRegistrationAutoCloseDateTime = DateTime.Now,
			         		StartDate = DateTime.Today,
			         		EndDate = DateTime.Today.AddDays(1.0), // tomorrow
							ShowEvents = false,
							ShowSpeakers = false,
							DisableLinkLocationCheck = false
						};
			try
			{
				rm = ResourceManager.CreateFileBasedResourceManager(fileBase,
																	_baseDir + dirName,
																	null);
				sd.FrontpageContent = rm.GetString("FrontpageContent") ??
									  Settings.FrontpageContent;
				sd.FrontpageTitle = rm.GetString("FrontpageTitle") ??
									Settings.FrontpageTitle;
				sd.EmailFrom = rm.GetString("EmailFrom") ?? Settings.EmailFrom;
				sd.EventRegistrationConfirmationBodyFormat =
					rm.GetString("EventRegistrationConfirmationBodyFormat") ??
					Settings.EventRegistrationConfirmationBodyFormat;
				sd.EventRegistrationConfirmationSubjectFormat =
					rm.GetString("EventRegistrationConfirmationSubjectFormat") ??
					Settings.EventRegistrationConfirmationSubjectFormat;
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
				sd.SmtpAuthenticationPassword =
					rm.GetString("SmtpAuthenticationPassword") ??
					Settings.SmtpAuthenticationPassword;
				sd.SmtpAuthenticationUserName =
					rm.GetString("SmtpAuthenticationUserName") ??
					Settings.SmtpAuthenticationUserName;
				sd.SmtpHostname =
					rm.GetString("SmtpHostname") ?? Settings.SmtpHostname;
				sd.SmtpPort =
					(int)(rm.GetObject("SmtpPort") ?? int.Parse(Settings.SmtpPort));
				sd.SmtpNeedsAuthentication =
					(bool)rm.GetObject("SmtpNeedsAuthentication");
				sd.RegistrationSubject = rm.GetString("RegistrationSubject");
				sd.RegistrationMessage = rm.GetString("RegistrationMessage");
				sd.MaxAttendees = (int) (rm.GetObject("MaxAttendees") ?? 0);
				sd.AttendeeRegistrationAutoCloseDateTime =
					(DateTime)
					(rm.GetObject("AttendeeRegistrationAutoCloseDateTime") ?? DateTime.Now);
				sd.MaxVolunteers = (int) (rm.GetObject("MaxVolunteers") ?? 0);
				sd.VolunteerRegistrationAutoCloseDateTime =
					(DateTime)
					(rm.GetObject("VolunteerRegistrationAutoCloseDateTime") ?? DateTime.Now);
				sd.MaxMechManiaTeams = (int) (rm.GetObject("MaxMechManiaTeams") ?? 0);
				sd.MechManiaRegistrationAutoCloseDateTime =
					(DateTime)
					(rm.GetObject("MechManiaRegistrationAutoCloseDateTime") ?? DateTime.Now);
				sd.StartDate = (DateTime) (rm.GetObject("StartDate") ?? DateTime.Today);
				sd.EndDate =
					(DateTime) (rm.GetObject("EndDate") ?? DateTime.Today.AddDays(1.0));
				sd.ShowEvents = (bool) rm.GetObject("ShowEvents");
				sd.ShowSpeakers = (bool) rm.GetObject("ShowSpeakers");
				sd.DisableLinkLocationCheck =
					(bool) rm.GetObject("DisableLinkLocationCheck");
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
			writer.AddResource("EventRegistrationConfirmationBodyFormat",
							   EventRegistrationConfirmationBodyFormat);
			writer.AddResource("EventRegistrationConfirmationSubjectFormat",
							   EventRegistrationConfirmationSubjectFormat);
			writer.AddResource("AttendeeBadgeBackground", AttendeeBadgeBackground);
			writer.AddResource("MechmaniaBadgeBackground", MechmaniaBadgeBackground);
			writer.AddResource("SpeakerBadgeBackground", SpeakerBadgeBackground);
			writer.AddResource("SponsorBadgeBackground", SponsorBadgeBackground);
			writer.AddResource("StaffBadgeBackground", StaffBadgeBackground);
			writer.AddResource("VolunteerBadgeBackground", VolunteerBadgeBackground);
			writer.AddResource("SmtpNeedsAuthentication", SmtpNeedsAuthentication);
			writer.AddResource("SmtpAuthenticationUserName", SmtpAuthenticationUserName);
			writer.AddResource("SmtpAuthenticationPassword", SmtpAuthenticationPassword);
			writer.AddResource("SmtpHostname", SmtpHostname);
			writer.AddResource("SmtpPort", SmtpPort);
			writer.AddResource("RegistrationSubject", RegistrationSubject);
			writer.AddResource("RegistrationMessage", RegistrationMessage);
			writer.AddResource("MaxAttendees", MaxAttendees);
			writer.AddResource("AttendeeRegistrationAutoCloseDateTime",
			                   AttendeeRegistrationAutoCloseDateTime);
			writer.AddResource("MaxVolunteers", MaxVolunteers);
			writer.AddResource("VolunteerRegistrationAutoCloseDateTime",
			                   VolunteerRegistrationAutoCloseDateTime);
			writer.AddResource("MaxMechManiaTeams", MaxMechManiaTeams);
			writer.AddResource("MechManiaRegistrationAutoCloseDateTime",
			                   MechManiaRegistrationAutoCloseDateTime);
			writer.AddResource("StartDate", StartDate);
			writer.AddResource("EndDate", EndDate);
			writer.AddResource("ShowEvents", ShowEvents);
			writer.AddResource("ShowSpeakers", ShowSpeakers);
			writer.AddResource("DisableLinkLocationCheck", DisableLinkLocationCheck);
			
			writer.Generate();
			writer.Close();
		}
	}
}