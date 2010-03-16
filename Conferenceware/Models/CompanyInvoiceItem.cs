namespace Conferenceware.Models
{
	public partial class CompanyInvoiceItem
	{
		// linq is your friend

		/// <summary>
		/// For Html.Hidden
		/// </summary>
		public int ItemId
		{
			get
			{
				return id;
			}
		}

	}
}