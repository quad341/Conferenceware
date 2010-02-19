using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{

	public class LocationMetadata
	{
		[Required]
		[StringLength(255)]
		public string building_name
		{
			get; set;
		}

		[Required]
		[StringLength(255)]
		public string room_number
		{
			get; set;
		}

		[Range(2, int.MaxValue)]
		public int max_occupants
		{
			get; set;
		}
	}

}