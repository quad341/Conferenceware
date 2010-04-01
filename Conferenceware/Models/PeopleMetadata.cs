using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class PeopleMetadata
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
		[RegularExpression(@"[A-Za-z0-9_%+-]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DataType(DataType.EmailAddress)]
		[DisplayName("EMail Address")]
		public string email
		{
			get;
			set;
		}

		[Required]
		[RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}",
			ErrorMessage = "Invalid phone number. Ex. 123-456-7890")]
		[DisplayName("Phone Number")]
		public string phone_number
		{
			get;
			set;
		}

		[DisplayName("University alum?")]
		public bool is_alum
		{
			get;
			set;
		}
	}
}