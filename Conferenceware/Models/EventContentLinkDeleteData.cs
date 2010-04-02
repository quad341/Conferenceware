using System.ComponentModel;

namespace Conferenceware.Models
{
	public class EventContentLinkDeleteData
	{
		[DisplayName("Delete the file?")]
		public bool DeleteFile
		{
			get;
			set;
		}

		[DisplayName("Delete the directory? (needs to be empty)")]
		public bool DeleteDir
		{
			get;
			set;
		}

		public EventContentLink EventContentLink
		{
			get;
			set;
		}
	}
}