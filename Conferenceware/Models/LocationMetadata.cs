using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class LocationMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("Building Name")]
		public string building_name { get; set; }

		[Required]
		[StringLength(255)]
		[DisplayName("Room Number")]
		public string room_number { get; set; }

		[Range(1, int.MaxValue)]
		[DisplayName("Max Capacity")]
		public int max_capacity { get; set; }

		[DisplayName("Notes")]
		public string notes { get; set; }
	}
}