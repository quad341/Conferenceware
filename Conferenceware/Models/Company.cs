using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(CompanyMetadata))]
	public partial class Company
	{
		// yay linq
		/// <summary>
		/// Convenience method to show how much invoices total to
		/// </summary>
		[DisplayName("Total for Invoices")]
		public decimal InvoiceTotal
		{
			get
			{
				return CompanyInvoices.Sum(x => x.TotalValue);
			}
		}

		/// <summary>
		/// Convenience property for how much payments total to
		/// </summary>
		[DisplayName("Total for Payments")]
		public decimal PaymentsTotal
		{
			get
			{
				return CompanyPayments.Sum(x => x.amount);
			}
		}

		/// <summary>
		/// Convenience property to show how much is owed by the company
		/// </summary>
		[DisplayName("Total Owed")]
		public decimal TotalOwed
		{
			get
			{
				return InvoiceTotal - PaymentsTotal;
			}
		}
	}
}