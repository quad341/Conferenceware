using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class CompanyMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("Company Name")]
		public string name
		{
			get;
			set;
		}

		[Required]
		[StringLength(255)]
		[DisplayName("Address (line 1)")]
		public string address_line1
		{
			get;
			set;
		}

		[StringLength(255)]
		[DisplayName("Address line 2")]
		public string address_line2
		{
			get;
			set;
		}

		[Required]
		[StringLength(255)]
		[DisplayName("City")]
		public string city
		{
			get;
			set;
		}

		[Required]
		[StringLength(2)]
		[RegularExpression(@"[A-Z]{2}", ErrorMessage = "State must be two capital letters (ex. IL)")]
		[DisplayName("State")]
		public string state
		{
			get;
			set;
		}

		[Required]
		[StringLength(5)]
		[RegularExpression(@"[0-9]{5}", ErrorMessage = "Zip code must be 5 numeric digits")]
		[DisplayName("Zip code")]
		public string zip
		{
			get;
			set;
		}

		[DisplayName("Need power at booth?")]
		public bool needs_power
		{
			get;
			set;
		}

		[DisplayName("Need priority shipping (ships out day of job fair)?")]
		public bool priority_shipping
		{
			get;
			set;
		}
	}
}