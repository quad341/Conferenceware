using System.Web.Mvc;

namespace Conferenceware.Models
{
	public class EventEditData
	{
		/// <summary>
		/// The event being editted
		/// </summary>
		public Event Event { get; set; }

		/// <summary>
		/// A list of locations for a drop down box
		/// </summary>
		public SelectList Locations { get; set; }

		/// <summary>
		/// A list of time slots for a drop down box
		/// </summary>
		public SelectList Timeslots { get; set; }

		/// <summary>
		/// A list of all the attendees in the system (alphabetical)
		/// </summary>
		public SelectList Attendees { get; set; }

		/// <summary>
		/// A list of all the speakers in the system (alphabetical)
		/// </summary>
		public SelectList Speakers { get; set; }

		/// <summary>
		/// A small helper so that state can be saved when redisplaying the form
		/// </summary>
		public int SelectedSpeaker { get; set; }

		/// <summary>
		/// A small helper for state relating to the select attendee
		/// </summary>
		public int SelectedAttendee { get; set; }
	}
}