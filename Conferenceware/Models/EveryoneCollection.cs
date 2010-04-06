using System.Collections.Generic;
using System.Linq;

namespace Conferenceware.Models
{
	public class EveryoneCollection
	{
		public IEnumerable<Attendee> Attendees
		{
			get;
			set;
		}

		public IEnumerable<MechManiaTeam> MechManiaTeams
		{
			get;
			set;
		}

		public IEnumerable<Speaker> Speakers
		{
			get;
			set;
		}

		public IEnumerable<CompanyPerson> CompanyPersons
		{
			get;
			set;
		}

		public IEnumerable<StaffMember> StaffMembers
		{
			get;
			set;
		}

		public IEnumerable<Volunteer> Volunteers
		{
			get;
			set;
		}

		public IEnumerable<CompanyPerson> Sponsors
		{
			get
			{
				return CompanyPersons;
			}
			set
			{
				CompanyPersons = value;
			}
		}

		public IEnumerable<Attendee> MechmaniaParticipants
		{
			get
			{
				var participants = new List<Attendee>(MechManiaTeams.Select(x => x.Attendee));
				participants.AddRange(MechManiaTeams.Select(x => x.Attendee1));
				participants.AddRange(MechManiaTeams.Select(x => x.Attendee2));
				return participants;
			}
		}
	}
}