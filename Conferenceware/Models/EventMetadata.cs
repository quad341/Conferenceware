using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class EventMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("Name")]
		public string name
		{
			get;
			set;
		}

		[Required]
		[DisplayName("Description")]
		public string description
		{
			get;
			set;
		}

		[Range(0, int.MaxValue)]
		[DisplayName("Max Capacity")]
		public int max_attendees
		{
			get;
			set;
		}
	}
}