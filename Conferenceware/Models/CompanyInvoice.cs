using System.Linq;

namespace Conferenceware.Models
{
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

	}
}