using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(CompanyInvoiceItemMetadata))]
	public partial class CompanyInvoiceItem
	{
		// linq is your friend

		/// <summary>
		/// For Html.Hidden
		/// </summary>
		public int ItemId
		{
			get { return id; }
		}
	}
}