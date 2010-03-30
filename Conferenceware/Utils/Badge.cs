using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace Conferenceware.Utils
{
    public class Badge
    {
        /// <summary>
        /// Take in an enumerable of people objects and a background image. Gives back a printable pdf of badges.
        /// </summary>
        /// <param name="people">People to print badges for.</param>
        /// <param name="background">Background image of badge.</param>
        /// <returns>PDF MemoryStream for returning to web user.</returns>
        static MemoryStream makeBadge(IEnumerable<Conferenceware.Models.People> people, System.Drawing.Image background)
        {
            //make a new document
            PdfDocument doc = new PdfDocument();
            // badge is about 4 inches wide and 3 inches tall
            var badge = new XForm(doc, XUnit.FromInch(3.0), XUnit.FromInch(4.0));
            // graphic for form
            var formGfx = XGraphics.FromForm(badge);
            // add background image to template
            formGfx.DrawImage(background, 0, 0);
            // Save the template to clone out with people's names
            var template = formGfx.Save();
            var font = new XFont("Verdana", 20, XFontStyle.Bold);
            var counter = 0;
            PdfPage page = null;
            XGraphics pageGfx = null;
            foreach (var person in people)
            {
                if (counter % 6 == 0)
                {
                    // add a new page
                    page = doc.AddPage();
                    // set it landscape
                    page.Orientation = PageOrientation.Landscape;
                    // make a graphic on the page
                    pageGfx = XGraphics.FromPdfPage(page);
                }
                // draw their name
                formGfx.DrawString(person.name, font, XBrushes.Black, new XRect(0, 0, XUnit.FromInch(3.0), XUnit.FromInch(4.0)), XStringFormats.Center);
                // one liner placement of badges on Avery 5392 cardstock
                pageGfx.DrawImage(badge, XUnit.FromInch(1 + (((counter % 6) / 3) * XUnit.FromInch(3.0))), XUnit.FromInch(0.25 + ((counter % 2) * XUnit.FromInch(4.0))));
                // reset template
                formGfx.Restore(template);
                counter += 1;
            }
            MemoryStream stream = new MemoryStream();
            doc.Save(stream, false);
            return stream;
        }
    }
}
