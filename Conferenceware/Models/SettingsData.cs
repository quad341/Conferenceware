using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;
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
		public const string RESOURCE_FILE_NAME = "~/App_Data/Settings.resource";
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

		public static SettingsData FromCurrent(string path)
		{
			ResourceReader reader = null;
			var sd = new SettingsData
						{
							FrontpageContent = Settings.FrontpageContent,
							FrontpageTitle = Settings.FrontpageTitle,
							EmailFrom = Settings.EmailFrom,
							EventRegistrationConfirmationSubjectFormat =
								Settings.EventRegistrationConfirmationSubjectFormat,
							EventRegistrationConfirmationBodyFormat =
								Settings.EventRegistrationConfirmationBodyFormat
						};
			try
			{
				reader = new ResourceReader(path);
				String outType;
				byte[] buffer;
				var encoding = new UTF8Encoding();
				reader.GetResourceData("FrontpageContent", out outType, out buffer);
				sd.FrontpageContent = encoding.GetString(buffer).Substring(1); // first character is length
				reader.GetResourceData("FrontpageTitle", out outType, out buffer);
				sd.FrontpageTitle = encoding.GetString(buffer).Substring(1);
				reader.GetResourceData("EmailFrom", out outType, out buffer);
				sd.EmailFrom = encoding.GetString(buffer).Substring(1);
				reader.GetResourceData("EventRegistrationConfirmationBodyFormat", out outType, out buffer);
				sd.EventRegistrationConfirmationBodyFormat = encoding.GetString(buffer).Substring(1);
				reader.GetResourceData("EventRegistrationConfirmationSubjectFormat", out outType, out buffer);
				sd.EventRegistrationConfirmationSubjectFormat = encoding.GetString(buffer).Substring(1);
				reader.Close();
			}
			catch
			{
				if (null != reader)
				{
					reader.Close();
				}
				// something went wrong; probably the file doesn't exist yet
			}
			return sd;
		}

		public void Save(string path)
		{
			var writer = new ResourceWriter(path);
			writer.AddResource("FrontpageContent", FrontpageContent);
			writer.AddResource("FrontpageTitle", FrontpageTitle);
			writer.AddResource("EmailFrom", EmailFrom);
			writer.AddResource("EventRegistrationConfirmationBodyFormat", EventRegistrationConfirmationBodyFormat);
			writer.AddResource("EventRegistrationConfirmationSubjectFormat", EventRegistrationConfirmationSubjectFormat);
			writer.Generate();
			writer.Close();
		}
	}
}