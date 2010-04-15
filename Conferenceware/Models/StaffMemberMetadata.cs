using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class StaffMemberMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("Username for authentication")]
		public string auth_name
		{
			get;
			set;
		}

		[Required]
		[DisplayName("Password")]
		public string password_hash
		{
			get;
			set;
		}
	}
}