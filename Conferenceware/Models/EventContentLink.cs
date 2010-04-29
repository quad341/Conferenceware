using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(EventContentLinkMetadata))]
	public partial class EventContentLink
	{
		//linq4life
		public string filename
		{
			get
			{
				if (link_location.Substring(0, link_location.LastIndexOf('/')) ==
					"/Content/" + event_id)
				{
					return link_location.Substring(link_location.LastIndexOf('/') + 1);
				}
				return link_location;
			}
		}

		public int ContentId
		{
			get { return id; }
		}
	}
}