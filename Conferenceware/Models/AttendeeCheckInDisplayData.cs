using System.Collections.Generic;

namespace Conferenceware.Models
{
	public class AttendeeCheckInDisplayData
	{
		/// <summary>
		/// The attendees to show
		/// </summary>
		public IEnumerable<Attendee> Attendees { get; set; }

		/// <summary>
		/// The query to show and pass on
		/// </summary>
		public string Query { get; set; }
	}
}