using System.Drawing;
using System.Drawing.Imaging;
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
				Image.Save(context.HttpContext.Response.OutputStream, ImageFormat.Png);
			}
		}
	}
}