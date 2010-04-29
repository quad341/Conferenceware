using System.Web.Mvc;

namespace Conferenceware.Models
{
	public class VolunteerTimeSlotScheduleData
	{
		public VolunteerTimeSlot VolunteerTs { get; set; }

		public SelectList Volunteers { get; set; }
	}
}