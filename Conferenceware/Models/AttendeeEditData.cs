using System.Web.Mvc;

namespace Conferenceware.Models
{
	/// <summary>
	/// Class to hold data for doing attendee creation and editting
	/// </summary>
	public class AttendeeEditData
	{
		/// <summary>
		/// The attendee
		/// </summary>
		public Attendee Attendee { get; set; }

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