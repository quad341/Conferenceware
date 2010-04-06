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
				return VolunteerTimeSlots.Where(x => x.is_video).Count() > 0;
			}
		}

		public IEnumerable<VolunteerTimeSlot> VolunteerTimeSlots
		{
			get
			{
				return VolunteersVolunteerTimeSlots.Select(x => x.VolunteerTimeSlot);
			}
		}
	}
}