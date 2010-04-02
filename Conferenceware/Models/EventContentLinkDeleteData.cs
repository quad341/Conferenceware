namespace Conferenceware.Models
{
	public class EventContentLinkDeleteData
	{
		public bool DeleteFile
		{
			get;
			set;
		}

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