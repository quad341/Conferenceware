using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class PageMetadata
	{
		[Required]
		[StringLength(255)]
		[RegularExpression(@"^[^{}|]+$", ErrorMessage = "Cannot contain a pipe or brace")]
		[DisplayName("Title (whitespace will be trimmed)")]
		public string title
		{
			get;
			set;
		}

		[Required]
		[DisplayName("Page Content (HTML ok)")]
		public string page_content
		{
			get;
			set;
		}

		[Range(0, int.MaxValue)]
		[DisplayName("Parent Page")]
		public int parent_id
		{
			get;
			set;
		}
	}
}