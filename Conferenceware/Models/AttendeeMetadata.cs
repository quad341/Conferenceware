using System.ComponentModel;

namespace Conferenceware.Models
{
	public class AttendeeMetadata
	{
		[DisplayName("T-Shirt Size")]
		public int tshirt_id
		{
			get;
			set;
		}

		[DisplayName("Food Choice")]
		public int food_choice_id
		{
			get;
			set;
		}
	}
}