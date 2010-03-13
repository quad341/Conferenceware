using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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

		public static SettingsData FromCurrent(string path)
		{
			ResourceReader reader = null;
			var sd = new SettingsData
					{
						FrontpageContent = Settings.FrontpageContent,
						FrontpageTitle = Settings.FrontpageTitle
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
			writer.Generate();
			writer.Close();
		}
	}
}