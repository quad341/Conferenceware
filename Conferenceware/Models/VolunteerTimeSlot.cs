using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(VolunteerTimeSlotMetadata))]
	public partial class VolunteerTimeSlot
	{
		// yay for great linq

		public IEnumerable<Volunteer> Volunteers
		{
			get
			{
				return VolunteersVolunteerTimeSlots.Select(x => x.Volunteer);
			}
		}

		public IEnumerable<Volunteer> UnscheduledVolunteers
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_scheduled == false).Select(
						x => x.Volunteer);
			}
		}

		public IEnumerable<Volunteer> UnconfirmedVolunteers
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_confirmed == false).Select(
						x => x.Volunteer);
			}
		}

		public IEnumerable<Volunteer> ScheduledVolunteers
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_scheduled).Select(
						x => x.Volunteer);
			}
		}

		public IEnumerable<Volunteer> ConfirmedVolunteers
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_confirmed).Select(
						x => x.Volunteer);
			}
		}
	}
}