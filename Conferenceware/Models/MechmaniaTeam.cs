using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(MechManiaTeamMetadata))]
	public partial class MechManiaTeam
	{
		// yay linq
		public IEnumerable<Attendee> Members
		{
			get
			{
				var members = new List<Attendee>(3);
				members.Add(Attendee);
				members.Add(Attendee1);
				members.Add(Attendee2);
				return members.Distinct();
			}
		}
	}
}