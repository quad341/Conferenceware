using System.ComponentModel;

namespace Conferenceware.Models
{
	public class CompanyPersonMetadata
	{
		[DisplayName("Attending the job fair?")]
		public bool is_attending { get; set; }

		[DisplayName("Should you be the primary contact for the company?")]
		public bool is_contact { get; set; }
	}
}