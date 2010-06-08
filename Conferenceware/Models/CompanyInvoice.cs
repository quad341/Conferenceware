using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace Conferenceware.Models
{
	[MetadataType(typeof(CompanyInvoiceMetadata))]
	public partial class CompanyInvoice
	{
		// linq does my work. how 'bout yours?

		public decimal TotalValue
		{
			get { return CompanyInvoiceItems.Sum(x => x.cost); }
		}

		/// <summary>
		/// For the bug with Html.Hidden
		/// </summary>
		public int InvoiceId
		{
			get { return id; }
		}
		/// <summary>
		/// Returns a memory stream that represents this invoice in pdf form
		/// Based on code from http://www.pdfsharp.net/wiki/Default.aspx?Page=Invoice-sample&NS=&AspxAutoDetectCookieSupport=1 as well as associated methods
		/// </summary>
		/// <returns>A memory stream containing a pdf</returns>
		public MemoryStream ToPdf()
		{
			// Create a new MigraDoc document
			var document = new Document();
			// Each MigraDoc document needs at least one section.
			// main content
			Section section = document.AddSection();
			document.Info.Title = "Invoice #"+id;

			// we have to put it in a file first because this thing only works on file paths
			var fileName = Path.GetTempFileName();
			SettingsData.Default.InvoiceLogo.Save(fileName);

			DefineStyles(document);
			CreateSectionIntro(section, fileName);
			AddAddressFrame(section);
			AddDateFields(section);
			var table = CreateTableWithHeader(section);
			PopulateTable(table);

			if (SettingsData.Default.NoteAfterInvoiceItemList != null)
			{
				// Add the notes paragraph
				var paragraph = document.LastSection.AddParagraph();
				paragraph.Format.SpaceBefore = "1cm";
				paragraph.Format.Borders.Width = 0.75;
				paragraph.Format.Borders.Distance = 3;
				paragraph.Format.Borders.Color = Colors.Black;
				paragraph.Format.Shading.Color = Colors.LightGray;
				paragraph.AddText(SettingsData.Default.NoteAfterInvoiceItemList);
			}

			var renderer = new PdfDocumentRenderer(true) {Document = document};
			renderer.PrepareRenderPages();
			renderer.RenderDocument();
			var pdf = renderer.PdfDocument;
			File.Delete(fileName);

			var ms = new MemoryStream();
			pdf.Save(ms, false);
			return ms;
			
		}
		/// <summary>
		/// Adds the invoice items to the table
		/// </summary>
		/// <param name="table"></param>
		private void PopulateTable(Table table)
		{
			// Iterate the invoice items
			decimal totalExtendedPrice = 0;
			foreach (var item in CompanyInvoiceItems)
			{

				// Each item fills two rows
				Row r = table.AddRow();
				r.TopPadding = 1.5;
				r.Cells[0].Format.Alignment = ParagraphAlignment.Left;
				r.Cells[1].Shading.Color = Colors.LightGray;

				r.Cells[0].AddParagraph(item.description);
				var paragraph = r.Cells[1].AddParagraph();
				paragraph.AddFormattedText(String.Format("{0:C}",item.cost), TextFormat.Bold);
				
				totalExtendedPrice += item.cost;
				table.SetEdge(0, table.Rows.Count - 1, 2, 1, Edge.Box, BorderStyle.Single, 0.75);
			}

			// Add an invisible row as a space line to the table
			Row row = table.AddRow();
			row.Borders.Visible = false;

			// Add the total price row
			row = table.AddRow();
			row.Cells[0].Borders.Visible = false;
			row.Cells[0].AddParagraph("Total Price");
			row.Cells[0].Format.Font.Bold = true;
			row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
			row.Cells[1].AddParagraph(String.Format("{0:C}", totalExtendedPrice));

			// Set the borders of the specified cell range
			table.SetEdge(1, table.Rows.Count - 1, 1, 1, Edge.Box, BorderStyle.Single, 0.75);

		}

		/// <summary>
		/// Creates the invoice table with header row
		/// </summary>
		/// <param name="section">The section onto which to create the table</param>
		/// <returns>The table</returns>
		private static Table CreateTableWithHeader(Section section)
		{
			// Create the item table
			var table = section.AddTable();
			table.Style = "Table";
			table.Borders.Color = Colors.Black;
			table.Borders.Width = 0.25;
			table.Borders.Left.Width = 0.5;
			table.Borders.Right.Width = 0.5;
			table.Rows.LeftIndent = 0;

			// Before you can add a row, you must define the columns
			//line number or item
			//Description
			Column column = table.AddColumn("12cm");
			column.Format.Alignment = ParagraphAlignment.Left;
			//Cost
			column = table.AddColumn("4cm");
			column.Format.Alignment = ParagraphAlignment.Right;

			// Create the header of the table
			Row row = table.AddRow();
			row.HeadingFormat = true;
			row.Format.Alignment = ParagraphAlignment.Center;
			row.Format.Font.Bold = true;
			row.Shading.Color = Colors.LightBlue;
			row.Cells[0].AddParagraph("Description"); //TODO localize
			row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
			row.Cells[1].AddParagraph("Cost"); //TODO localize
			row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
			table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);

			return table;
		}
		/// <summary>
		/// Creates the intro section of the invoice document
		/// </summary>
		/// <param name="section">The section to append to</param>
		/// <param name="fileName">The fileName of the logo to use</param>
		private static void CreateSectionIntro(Section section, string fileName)
		{

			// Put a logo in the header
			Image image = section.Headers.Primary.AddImage(fileName);
			image.Height = "2.5cm";
			image.LockAspectRatio = true;
			image.RelativeVertical = RelativeVertical.Line;
			image.RelativeHorizontal = RelativeHorizontal.Margin;
			image.Top = ShapePosition.Top;
			image.Left = ShapePosition.Right;
			image.WrapFormat.Style = WrapStyle.Through;

			if (SettingsData.Default.InvoiceFooterText != null)
			{
				// Create footer
				Paragraph footerParagraph = section.Footers.Primary.AddParagraph();
				footerParagraph.AddText(SettingsData.Default.InvoiceFooterText);
				footerParagraph.Format.Font.Size = 9;
				footerParagraph.Format.Alignment = ParagraphAlignment.Center;
			}

		}
		/// <summary>
		/// Adds Date field to the given section
		/// </summary>
		/// <param name="section">The section to append the date field to</param>
		private void AddDateFields(Section section)
		{
			var current = DateTime.Now;
			var due =
				current.AddMonths(SettingsData.Default.MonthsUntilInvoiceDue).AddDays(
					SettingsData.Default.DaysUntilInvoiceDue);
			var dateParagraph = section.AddParagraph();
			dateParagraph.Format.SpaceBefore = "8cm";
			dateParagraph.Style = "Reference";
			dateParagraph.AddFormattedText("INVOICE #"+id, TextFormat.Bold);
			dateParagraph.AddTab();
			dateParagraph.AddText(String.Format("Date: {0:yyyy-MM-dd}", current));
			dateParagraph.AddLineBreak();
			dateParagraph.AddTab();
			dateParagraph.AddText(String.Format("Due: {0:yyyy-MM-dd}", due));
		}
		/// <summary>
		/// Adds the sender and receiver addresses to the given section
		/// </summary>
		/// <param name="section">The section to append the sender and receiver to</param>
		private void AddAddressFrame(Section section)
		{
			var addressFrame = section.AddTextFrame();
			addressFrame.Height = "3.0cm";
			addressFrame.Width = "7.0cm";
			addressFrame.Left = ShapePosition.Left;
			addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
			addressFrame.Top = "5.0cm";
			addressFrame.RelativeVertical = RelativeVertical.Page;

			// Put sender in address frame
			var senderParagraph =
				addressFrame.AddParagraph(SettingsData.Default.SenderText);
			senderParagraph.Format.Font.Name = "Times New Roman";
			senderParagraph.Format.Font.Size = 7;
			senderParagraph.Format.SpaceAfter = 3;

			// Put receiver in address frame
			Paragraph receiverParagraph = addressFrame.AddParagraph();
			receiverParagraph.AddText(Company.name);
			receiverParagraph.AddLineBreak();
			receiverParagraph.AddText(Company.address_line1);
			receiverParagraph.AddLineBreak();
			if(!String.IsNullOrEmpty(Company.address_line2))
			{
				receiverParagraph.AddText(Company.address_line2);
				receiverParagraph.AddLineBreak();
			}
			receiverParagraph.AddText(String.Format("{0}, {1} {2}",
			                                        Company.city,
			                                        Company.state,
			                                        Company.zip));
		}
		/// <summary>
		/// Adds the styles to the document
		/// </summary>
		/// <param name="document">The document to add styles to</param>
		private static void DefineStyles(Document document)
		{
			// Get the predefined style Normal.
			Style style = document.Styles["Normal"];
			// Because all styles are derived from Normal, the next line changes the 
			// font of the whole document. Or, more exactly, it changes the font of
			// all styles and paragraphs that do not redefine the font.
			style.Font.Name = "Verdana";

			style = document.Styles[StyleNames.Header];
			style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

			style = document.Styles[StyleNames.Footer];
			style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

			// Create a new style called Table based on style Normal
			style = document.Styles.AddStyle("Table", "Normal");
			style.Font.Name = "Verdana";
			style.Font.Name = "Times New Roman";
			style.Font.Size = 9;

			// Create a new style called Reference based on style Normal
			style = document.Styles.AddStyle("Reference", "Normal");
			style.ParagraphFormat.SpaceBefore = "5mm";
			style.ParagraphFormat.SpaceAfter = "5mm";
			style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

		}
	}
}