using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class CompanyPaymentMetadata
	{
		[Range(0, int.MaxValue, ErrorMessage = "Payment amount must be positive")]
		[DisplayName("Payment amount")]
		public decimal amount
		{
			get;
			set;
		}

		[Required]
		[DataType(DataType.DateTime)]
		[Range(typeof(DateTime), "1/1/2000", "12/31/9999")]
		[DisplayName("Received Date")]
		public DateTime received_date
		{
			get;
			set;
		}

		[DisplayName("Comments")]
		public string comments
		{
			get;
			set;
		}
	}
}