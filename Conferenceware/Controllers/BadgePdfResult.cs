using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class BadgePdfResult : ActionResult
	{
		private const int BUFFER_SIZE = 512;
		public BadgePdfResult(IEnumerable<People> people, Image background, String filename)
		{
			People = people;
			Background = background;
			Filename = filename;
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

		public string Filename
		{
			get;
			set;
		}

		//
		// This class is used to return a special pdf type instead of a view
		// this is where that result is processed and shown to the user
		//
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Clear();
			context.HttpContext.Response.ContentType = "application/pdf";
			context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + Filename);
			// make pdf, send to output stream
			var ms = Badge.MakeBadge(People, Background);
			ms.Seek(0, SeekOrigin.Begin);
			var buffer = new byte[BUFFER_SIZE];
			var readBytes = ms.Read(buffer, 0, BUFFER_SIZE);
			while (readBytes > 0)
			{
				context.HttpContext.Response.OutputStream.Write(buffer, 0, readBytes);
				readBytes = ms.Read(buffer, 0, BUFFER_SIZE);
			}
		}
	}
}
