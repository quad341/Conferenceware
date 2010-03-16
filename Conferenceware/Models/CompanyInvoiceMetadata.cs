using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class CompanyInvoiceMetadata
	{
		[DisplayName("When this version of the invoice was created")]
		public DateTime created
		{
			get;
			set;
		}

		[DisplayName("Last time this version of invoice was sent to company")]
		[Range(typeof(DateTime), "2000-01-01", "9999-12-31")]
		public DateTime last_sent
		{
			get;
			set;
		}

		[DisplayName("Invoice Paid?")]
		public bool paid
		{
			get;
			set;
		}

		[DisplayName("When the invoice was marked paid")]
		public DateTime marked_paid_date
		{
			get;
			set;
		}
	}
}