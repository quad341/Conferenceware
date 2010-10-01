using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class MechmaniaTeamEditData
	{
		/// <summary>
		/// Mechmania team name
		/// </summary>
		[Required]
		[StringLength(255)]
		[DisplayName("Team Name")]
		public String team_name { get; set; }

		/// <summary>
		/// First team member's email
		/// </summary>
		[Required]
		[RegularExpression(@"[A-Za-z0-9_%+-\.]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("Member 1 Email")]
		public String member_email_1 { get; set; }

		/// <summary>
		/// Second team member's email
		/// </summary>
		[Required]
		[RegularExpression(@"[A-Za-z0-9_%+-\.]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("Member 2 Email")]
		public String member_email_2 { get; set; }

		/// <summary>
		/// Third team member's email
		/// </summary>
		[Required]
		[RegularExpression(@"[A-Za-z0-9_%+-\.]+@([A-Za-z0-9-]+\.)+[A-Za-z]{2,4}",
			ErrorMessage = "Invalid Email Provided")]
		[DisplayName("Member 3 Email")]
		public String member_email_3 { get; set; }
	}
}
