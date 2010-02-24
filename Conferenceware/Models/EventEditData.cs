using System.Web.Mvc;

namespace Conferenceware.Models
{
	public class EventEditData
	{
		/// <summary>
		/// The event being editted
		/// </summary>
		public Event Event
		{
			get;
			set;
		}

		/// <summary>
		/// A list of locations for a drop down box
		/// </summary>
		public SelectList Locations
		{
			get;
			set;
		}

		/// <summary>
		/// A list of time slots for a drop down box
		/// </summary>
		public SelectList Timeslots
		{
			get;
			set;
		}
	}
}