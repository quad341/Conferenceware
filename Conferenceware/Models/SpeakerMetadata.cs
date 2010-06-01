using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class SpeakerMetadata
	{
		[Required]
		[DisplayName("Biography (HTML ok)")]
		public string bio { get; set; }
	}
}