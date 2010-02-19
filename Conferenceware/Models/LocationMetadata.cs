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

		[Range(1, int.MaxValue)]
		public int max_capacity
		{
			get; set;
		}
	}

}