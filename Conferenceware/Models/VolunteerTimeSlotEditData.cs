using System.Web.Mvc;

namespace Conferenceware.Models
{
	public class VolunteerTimeSlotEditData
	{
		public VolunteerTimeSlot VolunteerTimeSlot
		{
			get;
			set;
		}

		public SelectList Timeslots
		{
			get;
			set;
		}

	}
}