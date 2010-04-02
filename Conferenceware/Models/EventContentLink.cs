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
				return link_location.Substring(link_location.LastIndexOf('/'));
			}
		}
	}
}