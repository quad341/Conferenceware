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

		public static string ConvertMarkupToHtml(string markupString, HtmlHelper htmlHelper)
		{
			_html = htmlHelper;
			var linkFixedString = Regex.Replace(markupString, PAGE_LINK_REGEX, new MatchEvaluator(FixPageLink));
			return Regex.Replace(linkFixedString, @"\\{", "{");
		}

		public static string FixPageLink(Match match)
		{
			var title = match.Captures[0].Value;
			if (match.Captures.Count == 2)
			{
				title = match.Captures[1].Value;
			}
			return LinkExtensions.ActionLink(_html,
											 title,
											 "View",
											 "Page",
											 new { name = match.Captures[0].Value.Trim() },
											 null);
		}
	}
}