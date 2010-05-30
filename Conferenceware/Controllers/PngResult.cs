using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace Conferenceware.Controllers
{
	public class PngResult : ActionResult
	{
		public PngResult(Image img)
		{
			Image = img;
		}

		public Image Image { get; set; }

		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Clear();
			context.HttpContext.Response.ContentType = "image/png";
			if (Image != null)
			{
				// this memory stream business is a hack due to an error i was getting
				// when not doing it. hopefully it can be removed, but it works for now
				using (var m = new MemoryStream())
				{
					Image.Save(m, ImageFormat.Png);
					context.HttpContext.Response.OutputStream.Write(m.GetBuffer(),
					                                                0,
					                                                Convert.ToInt32(m.Length));
				}
			}
		}
	}
}