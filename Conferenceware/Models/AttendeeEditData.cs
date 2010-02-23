using System.Collections.Generic;

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
		public Attendee Attendee
		{
			get; set;
		}

		/// <summary>
		/// A list of all the t shirt sizes
		/// </summary>
		public IEnumerable<TShirtSize> TShirtSizes
		{
			get; set;
		}

		/// <summary>
		/// A list of all the food choices
		/// </summary>
		public IEnumerable<Food> Foods
		{
			get; set;
		}
	}

}