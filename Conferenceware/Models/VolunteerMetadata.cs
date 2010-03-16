using System.ComponentModel;

namespace Conferenceware.Models
{
	public class VolunteerMetadata
	{
		[DisplayName("Is video trained?")]
		public bool is_video_trained
		{
			get;
			set;
		}
	}
}