using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(VolunteerMetadata))]
	public partial class Volunteer
	{
		// we all love linq

		public bool NeedsVideoTraining
		{
			get
			{
				return ConfirmedVolunteerTimeSlots.Where(x => x.is_video).Count() > 0;
			}
		}

		public IEnumerable<VolunteerTimeSlot> VolunteerTimeSlots
		{
			get
			{
				return VolunteersVolunteerTimeSlots.Select(x => x.VolunteerTimeSlot);
			}
		}

		public IEnumerable<VolunteerTimeSlot> ScheduledVolunteerTimeSlots
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_scheduled).Select(
						x => x.VolunteerTimeSlot);
			}
		}

		public IEnumerable<VolunteerTimeSlot> ConfirmedVolunteerTimeSlots
		{
			get
			{
				return
					VolunteersVolunteerTimeSlots.Where(x => x.is_confirmed).Select(
						x => x.VolunteerTimeSlot);
			}
		}
	}
}