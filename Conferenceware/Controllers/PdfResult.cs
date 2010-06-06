using System;
using System.IO;
using System.Web.Mvc;

namespace Conferenceware.Controllers
{
	public class PdfResult : ActionResult
	{
		private const int BUFFER_SIZE = 512;

		public PdfResult()
		{
		}

		public PdfResult (string file) : this(null, file)
		{
		}

		public PdfResult(MemoryStream ms) : this(ms, null)
		{
		}

		public PdfResult (MemoryStream ms, string file)
		{
			Pdf = ms;
			Filename = file;
		}

		public MemoryStream Pdf { get; set; }

		public String Filename { get; set; }

		public override void ExecuteResult(ControllerContext context)
		{
			if (Pdf == null)
			{
				throw new InvalidDataException();
			}
			
			context.HttpContext.Response.Clear();
			context.HttpContext.Response.ContentType = "application/pdf";
			context.HttpContext.Response.AddHeader("Content-Disposition",
												   "attachment; filename=" + Filename ?? "attachment.pdf");
			Pdf.Seek(0, SeekOrigin.Begin);
			var buffer = new byte[BUFFER_SIZE];
			int readBytes = Pdf.Read(buffer, 0, BUFFER_SIZE);
			while (readBytes > 0)
			{
				context.HttpContext.Response.OutputStream.Write(buffer, 0, readBytes);
				readBytes = Pdf.Read(buffer, 0, BUFFER_SIZE);
			}
		}
	}
}