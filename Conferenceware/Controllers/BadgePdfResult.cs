using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class BadgePdfResult : ActionResult
	{
		public BadgePdfResult(IEnumerable<People> people, Image background)
		{
			People = people;
			Background = background;
		}
		public Image Background
		{
			get;
			set;
		}
		public IEnumerable<People> People
		{
			get;
			set;
		}
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Clear();
			context.HttpContext.Response.ContentType = "application/pdf";
			// make pdf, send to output stream
			Badge.MakeBadge(People, Background, context.HttpContext.Response.OutputStream);
		}
	}
}