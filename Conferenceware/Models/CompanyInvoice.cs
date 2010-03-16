using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(CompanyInvoiceMetadata))]
	public partial class CompanyInvoice
	{
		// linq does my work. how 'bout yours?

		public decimal TotalValue
		{
			get
			{
				return CompanyInvoiceItems.Sum(x => x.cost);
			}
		}

		/// <summary>
		/// For the bug with Html.Hidden
		/// </summary>
		public int InvoiceId
		{
			get
			{
				return id;
			}
		}

	}
}