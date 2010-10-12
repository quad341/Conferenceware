using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class SpeakerMetadata
	{
		[Required]
		[DisplayName("Biography (HTML ok)")]
		public string bio { get; set; }

        [DisplayName("Speaker Pic URL (full path) (Optional)")]
        [RegularExpression(@"^http://www.acm.uiuc.edu/.*", ErrorMessage="Please use a full path")]
        public string image { get; set; }
	}
}