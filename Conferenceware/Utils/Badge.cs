using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Conferenceware.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

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
		public static MemoryStream MakeBadge(IEnumerable<People> people,
											 Image background)
		{
			// settings for Avery 5392 cardstock with badges printed vertically (taller than wide)
			// offsets used to layout the text
			const double baseXOffset = 1.0;
			const double baseYOffset = .25;
			const double imageXOffset = .1;
			const double imageYOffset = .1;
			const double textWidth = 2.5;
			const double nameTextXOffset = .25;
			const double nameTextYOffset = 2.3;
			const double nameTextHeight = .3;
			const double companyTextXOffset = .25;
			const double companyTextYOffset = 2.7;
			const double companyTextHeight = .2;
			const double alumTextXOffset = .25;
			const double alumTextYOffset = 2.9;
			const double alumTextHeight = .2;
			const double badgeWidth = 2.8;
			const double badgeHeight = 3.8;
			const int maxNameBigFontLength = 17;
			const int bigFontSize = 20;
			const int smallFontSize = 16;
			const int titleFontSize = 14;
			const string fontName = "Helvetica";
			const XFontStyle nameFontStyle = XFontStyle.Regular;
			const XFontStyle titleFontStyle = XFontStyle.Regular;
			// the rest just build it
			//make a new document
			var doc = new PdfDocument();
			// badge is 4 inches wide and 3 inches tall
			// it's smaller here so we can leave some spacing around the edges so they print right
			var badge = new XForm(doc,
								  XUnit.FromInch(badgeWidth),
								  XUnit.FromInch(badgeHeight));
			// graphic for form
			XGraphics formGfx = XGraphics.FromForm(badge);
			// add background image to template
			formGfx.DrawImage(background, 0, 0);
			// Save the template to clone out with people's names
			//var template = formGfx.Save();
			int counter = 0;
			PdfPage page;
			XGraphics pageGfx = null;
			foreach (People person in people)
			{
				// make long names smaller
				int fontSize = person.name.Length > maxNameBigFontLength
								? smallFontSize
								: bigFontSize;
				var nameFont = new XFont(fontName, fontSize, nameFontStyle);
				var titleFont = new XFont(fontName, titleFontSize, titleFontStyle);
				// there are 3 columns with 2 rows with each column being 3 inches and row being 4 inches
				// these offsets choose which badge is being printed by simple algebra
				double columnOffset = ((counter % 6) / 2) * 3.0;
				double rowOffset = (counter % 2) * 4.0;
				if (counter % 6 == 0)
				{
					// add a new page
					page = doc.AddPage();
					// set it landscape
					page.Orientation = PageOrientation.Landscape;
					// make a graphic on the page
					pageGfx = XGraphics.FromPdfPage(page);
				}
				// one liner placement of badges
				pageGfx.DrawImage(badge,
								  XUnit.FromInch(baseXOffset + columnOffset + imageXOffset),
								  XUnit.FromInch(baseYOffset + rowOffset + imageYOffset));
				// draw their name
				pageGfx.DrawString(person.name,
								   nameFont,
								   XBrushes.Black,
								   new XRect(
									XUnit.FromInch(baseXOffset + columnOffset +
												   nameTextXOffset),
									XUnit.FromInch(baseYOffset + rowOffset + nameTextYOffset),
									XUnit.FromInch(textWidth),
									XUnit.FromInch(nameTextHeight)),
								   XStringFormats.Center);
				// draw their title (company, alum)
				if (person.CompanyPerson != null)
				{
					pageGfx.DrawString(person.CompanyPerson.Company.name,
									   titleFont,
									   XBrushes.Black,
									   new XRect(
										XUnit.FromInch(baseXOffset + columnOffset +
													   companyTextXOffset),
										XUnit.FromInch(baseYOffset + rowOffset +
													   companyTextYOffset),
										XUnit.FromInch(textWidth),
										XUnit.FromInch(companyTextHeight)),
									   XStringFormats.Center);
				}
				if (person.is_alum)
				{
					pageGfx.DrawString("Alum",
									   titleFont,
									   XBrushes.Black,
									   new XRect(
										XUnit.FromInch(baseXOffset + columnOffset +
													   alumTextXOffset),
										XUnit.FromInch(baseYOffset + rowOffset +
													   alumTextYOffset),
										XUnit.FromInch(textWidth),
										XUnit.FromInch(alumTextHeight)),
									   XStringFormats.Center);
				}

				// reset template
				//formGfx.Restore(template);
				counter += 1;
			}
			var ms = new MemoryStream();
			doc.Save(ms, false);
			return ms;
		}
	}
}