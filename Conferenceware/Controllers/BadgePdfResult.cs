using System;
using System.Collections.Generic;
using System.Drawing;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class BadgePdfResult : PdfResult
	{
		
		public BadgePdfResult(IEnumerable<People> people,
							  Image background,
							  String filename)
		{
			People = people;
			Background = background;
			Filename = filename;
			Pdf = Badge.MakeBadge(People, Background);
		}

		public Image Background { get; set; }
		public IEnumerable<People> People { get; set; }
	}
}