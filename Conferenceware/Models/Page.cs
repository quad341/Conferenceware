using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Conferenceware.Models
{
	[MetadataType(typeof(PageMetadata))]
	public partial class Page
	{
		private const string PAGE_LINK_REGEX =
			@"{\s*{\s*([^{}|]+)(?:\|([^{}]+))?\s*}\s*}";

		private static HtmlHelper _html;

		// linq to my lou

		public string ConvertedContent(HtmlHelper html)
		{
			return ConvertMarkupToHtml(page_content, html);
		}

		public static string ConvertMarkupToHtml(string markupString,
												 HtmlHelper htmlHelper)
		{
			_html = htmlHelper;
			string linkFixedString = Regex.Replace(markupString,
												   PAGE_LINK_REGEX,
												   new MatchEvaluator(FixPageLink));
			return Regex.Replace(linkFixedString, @"\\{", "{");
		}

		public static string FixPageLink(Match match)
		{
			string title = match.Groups[1].Value.Trim();
			if (match.Groups[2].Value != "")
			{
				title = match.Groups[2].Value.Trim();
			}
			return
				_html.ActionLink(title,
								 "Display",
								 "Page",
								 new { name = match.Groups[1].Value.Trim() },
								 null).ToString();
		}
	}
}