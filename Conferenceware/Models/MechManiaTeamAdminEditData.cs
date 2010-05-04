using System.Web.Mvc;

namespace Conferenceware.Models
{
	public class MechManiaTeamAdminEditData
	{
		public MechManiaTeam MechManiaTeam { get; set; }

		public SelectList Attendees { get; set; }
	}
}