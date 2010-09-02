using System.Collections.Generic;
using System.Web.Mvc;

namespace Conferenceware.Models
{
	/// <summary>
	/// Class to hold data for volunteer creation and editting
	/// </summary>
	public class VolunteerEditData
	{
		/// <summary>
		/// The volunteer
		/// </summary>
		public Volunteer Volunteer { get; set; }

		/// <summary>
		/// A list of the volunteer time slots
		/// </summary>
		public IEnumerable<VolunteerTimeSlot> VolunteerTimeSlots { get; set; }

		/// <summary>
		/// The time slots that a volunteer has chosen
		/// </summary>
		public int[] ChosenTimeSlots { get; set; }

		/// <summary>
		/// A list of all the t shirt sizes
		/// </summary>
		public SelectList TShirtSizes { get; set; }

		/// <summary>
		/// A list of all the food choices
		/// </summary>
		public SelectList Foods { get; set; }
	}
}