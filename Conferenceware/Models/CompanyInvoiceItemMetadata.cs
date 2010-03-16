using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class CompanyInvoiceItemMetadata
	{
		[Required]
		[StringLength(255)]
		[DisplayName("Name")]
		public string name
		{
			get;
			set;
		}

		[DisplayName("Description")]
		public string description
		{
			get;
			set;
		}

		[Range(0, int.MaxValue)]
		[DisplayName("Cost for item")]
		public decimal cost
		{
			get;
			set;
		}

	}
}