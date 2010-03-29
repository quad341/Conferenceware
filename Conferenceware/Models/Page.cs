using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Conferenceware.Models
{
	[MetadataType(typeof(PageMetadata))]
	public partial class Page
	{
		private static HtmlHelper _html;
		private const string PAGE_LINK_REGEX =
			@"{\s*{\s*([^{}|])(?:|([^{}]))?\s*}\s*}";
		// linq to my lou

		public string ConvertedContent(HtmlHelper html)
		{
			return ConvertMarkupToHtml(page_content, html);
		}

		public static string ConvertMarkupToHtml(string markupString, HtmlHelper htmlHelper)
		{
			_html = htmlHelper;
			var linkFixedString = Regex.Replace(markupString,
												PAGE_LINK_REGEX,
												new MatchEvaluator(FixPageLink));
			return Regex.Replace(linkFixedString, @"\\{", "{");
		}

		public static string FixPageLink(Match match)
		{
			var title = match.Captures[0].Value;
			if (match.Captures.Count == 2)
			{
				title = match.Captures[1].Value;
			}
			return
				_html.ActionLink(title,
								 "View",
								 "Page",
								 new { name = match.Captures[0].Value.Trim() },
								 null).ToString();
		}
	}
}