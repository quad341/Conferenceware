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
	[Serializable]
	public class SettingsData
	{
		/// <summary>
		/// Cached version of the default instance since it doesn't change often really
		/// </summary>
		protected static SettingsData _defaultInstance = null;
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
		/// The email address that is automatically added to all outgoing messages as a bcc (usually for storage)
		/// </summary>
		[RegularExpression(@"[A-Za-z0-9_%+-]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("Address for email sent by the system to automatically bcc")]
		public string BCCEmail { get; set; }

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
		[Range(0, int.MaxValue)]
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
		/// The year of the conference (ie. the 15th year)
		/// </summary>
		[Range(1,int.MaxValue)]
		[DisplayName("Conference Annum (eg. the 15th year)")]
		public int Annum { get; set; }

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
		#endregion

		#region ErrorCheckingSettings
		/// <summary>
		/// Whether or not to disable the location check for linked files for events
		/// 
		/// This can be useful especially if the server is sitting behind a load balancer
		///  or otherwise if its urls are not what one would need to access the files
		/// </summary>
		[DisplayName("Disable the location verification on linked files?")]
		public bool DisableLinkLocationCheck { get; set; }
		
		/// <summary>
		/// Disables a check to see if a timeslot starts before the conference starts
		/// </summary>
		[DisplayName("Allow Time Slots before conference start?")]
		public bool AllowTimeSlotsBeforeStart { get; set; }

		/// <summary>
		/// Disables a check to see if a timeslot ends after the conference ends
		/// </summary>
		[DisplayName("Allow Time Slots after conference end?")]
		public bool AllowTimeSlotsAfterEnd { get; set; }
		#endregion

		public static SettingsData Default
		{
			get
			{
				if (_defaultInstance == null)
				{
					_defaultInstance = FromCurrent(RESOURCE_FILE_NAME, RESOURCE_FILE_DIR);
				}
				return _defaultInstance;
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
				sd = rm.GetObject("SettingsData") as SettingsData ?? sd;
			}
			// ReSharper disable EmptyGeneralCatchClause
			catch
			// ReSharper restore EmptyGeneralCatchClause
			{
				// something went wrong; probably the file doesn't exist yet
			}
			finally
			{
				if (rm != null)
				{
					rm.ReleaseAllResources();
				}
			}
			return sd;
		}

		public void Save(string path)
		{
			var writer = new ResourceWriter(_baseDir + path);
			writer.AddResource("SettingsData", this);
			writer.Generate();
			writer.Close();
		}
	}
}