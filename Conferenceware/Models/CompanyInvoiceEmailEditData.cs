using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	/// <summary>
	/// Class to hold data for sending Company Invoice Emails
	/// </summary>
	public class CompanyInvoiceEmailEditData
	{
		/// <summary>
		/// The id of the invoice
		/// </summary>
		public int CompanyInvoiceId { get; set; }
		/// <summary>
		/// The array of ids for the recipiants
		/// </summary>
		[Required(ErrorMessage = "At least one recipiant is required")]
		public int[] SelectedRecipiants { get; set; }
		/// <summary>
		/// The subject of the email
		/// </summary>
		[Required]
		[StringLength(255)]
		public string Subject { get; set; }
		/// <summary>
		/// The body of the email
		/// </summary>
		[Required]
		public string Body { get; set; }
		/// <summary>
		/// The name for the attachment (the invoice as a pdf)
		/// </summary>
		[Required]
		[StringLength(255)]
		[DisplayName("Attachment Name")]
		public string InvoiceAttachmentFileName { get; set; }
		/// <summary>
		/// The initial list of people that could be selected as recipiants
		/// </summary>
		public IEnumerable<CompanyPerson> PeopleChoices { get; set; }
	}
}