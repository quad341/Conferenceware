using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Conferenceware.Utils
{
	public class ImageHelper
	{
		public static string BitmapToBase64(Bitmap b)
		{
			if (b == null)
			{
				return "";
			}
			// based strongly on http://www.dailycoding.com/Posts/convert_image_to_base64_string_and_base64_string_to_image.aspx
			using (var ms = new MemoryStream())
			{
				// Convert Image to byte[]
				//image.Save(ms, format);
				b.Save(ms, ImageFormat.Bmp);
				byte[] imageBytes = ms.ToArray();

				// Convert byte[] to Base64 String
				return Convert.ToBase64String(imageBytes);
			}
		}

	}
}