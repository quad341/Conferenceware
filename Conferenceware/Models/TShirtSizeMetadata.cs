using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class TShirtSizeMetadata
	{
		[Required]
		[StringLength(255)]
		public string name { get; set; }
	}
}