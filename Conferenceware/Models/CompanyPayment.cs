using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(CompanyPaymentMetadata))]
	public partial class CompanyPayment
	{
		// linq spins you right round

		/// <summary>
		/// This is for helping with a bug in Html.Hidden where it finds the ModelStateDictionary["id"] before the parameter's
		/// </summary>
		public int payment_id
		{
			get { return id; }
		}
	}
}