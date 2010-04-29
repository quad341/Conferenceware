using System.Collections.Generic;

namespace Conferenceware.Models
{
	public class VolunteerEditData
	{
		public Volunteer Volunteer { get; set; }

		public IEnumerable<VolunteerTimeSlot> VolunteerTimeSlots { get; set; }

		public int[] ChosenTimeSlots { get; set; }
	}
}