using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class EventContentLinkMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("File to link (url needed in browser to select file)")]
		public string link_location
		{
			get;
			set;
		}
	}
}