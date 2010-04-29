using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class EmailEditData
	{
		[DisplayName(
			"Should Individual Emails be sent? ({name} can be used to specify the receiver's name with individual emails only, but it is slower than just BCCing all the addresses)"
			)]
		public bool SendIndividualEmails { get; set; }

		[Required]
		[DisplayName("Email message (body)")]
		public string Message { get; set; }

		[Required]
		[DisplayName("Email Subject")]
		public string Subject { get; set; }

		public int[] SelectedPeopleIds { get; set; }

		public EveryoneCollection Everyone { get; set; }
	}
}