using iTextSharp.text;
using iTextSharp.text.pdf;
using MachenicWpf.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MachenicWpf.Utils {
    public class PdfHelper {
        private PdfHelper() {

        }

        public static void Export(int type, IType model, Order infor, string filePath) {

            var imgFiles = new List<string>();
            for (int i = 1; i <= 4; i++) {
                imgFiles.Add(string.Format("{0}_{1}.png", type, i));
            }

            // Write information into file
            Document document = new Document(PageSize.A4, 14, 14, 14, 14);
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            try {

                var writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.AddTitle("My Title");
                document.AddAuthor("Me");
                document.Open();
                document.NewPage();

                // Draw border
                WriteBorder(document, writer);
                MaterialTable(writer, infor, model);
                var tableHeight = WriteSignature(writer, infor, model);
                var remainHeight = PageSize.A4.Width - tableHeight - 28;
                var width = PageSize.A4.Height - 28;
                int index = 0;
                foreach (var img in imgFiles) {
                    if (index > 0) {
                        document.NewPage();
                        WriteBorder(document, writer);
                        WriteSignature(writer, infor, model);
                    }
                    var processImg = ImgHelper.GenerateTemp(type, index + 1, Path.Combine("./Data", img), model.GetAllValues());
                    Image jpg = Image.GetInstance(processImg);

                    jpg.ScaleToFit(width, remainHeight);
                    jpg.BorderWidth = 5f;
                    document.Add(jpg);
                    index++;
                    File.Delete(processImg);
                }

            } catch (Exception ex) {
                //Log error;

            } finally {
                document.Close();
            }
        }

        private static void WriteBorder(Document document, PdfWriter writer) {
            var cb = writer.DirectContent;
            cb.SetLineWidth(1.4f);
            cb.MoveTo(14, 14);
            cb.LineTo(827, 14);
            cb.Stroke();
            cb.MoveTo(827, 14);
            cb.LineTo(827, 581);

            cb.Stroke();
            cb.MoveTo(827, 581);
            cb.LineTo(14, 581);
            cb.Stroke();
            cb.MoveTo(14, 581);
            cb.LineTo(14, 14);
            cb.Stroke();
        }

        private static float WriteSignature(PdfWriter writer, Order infor, IType model) {
            PdfPTable table = new PdfPTable(3);
            var allData = model.GetAllValues();
            //PdfPCell cell = new PdfPCell(new Phrase(string.Format("RL.{0}.{1}.{2}", allData["D"], allData["L"], allData["Bearing"])));
            PdfPCell cell = new PdfPCell(new Phrase("WEIGHT OF ROLLER: " +model.WeightOfRoller() +" kg"));
            table.HorizontalAlignment = 2;

            cell.Colspan = 3;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(string.Format("Order\r\n{0}", infor.OrderNo)));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(string.Format("Customer\r\n{0}", infor.CustomerName)));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(string.Format("Quantity (pcs)\r\n{0:D2}", infor.Quantity)));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            var data = model.GetAllValues();
            cell = new PdfPCell(new Phrase("Roller diameter\r\n" + data["D"].ToString()));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Roller length \r\n" + data["L"].ToString()));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Bearing\r\n" + data["Bearing"].ToString()));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            //table.WidthPercentage = 50.0f;

            table.SetTotalWidth(new float[] { 120f, 131f, 120f });
            float h = table.TotalHeight;

            table.WriteSelectedRows(0, -1, 827 - table.TotalWidth, h + 14, writer.DirectContent);
            return table.TotalHeight;
        }
        private static float MaterialTable(PdfWriter writer, Order infor, IType model) {
            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("SPECIFICATION OF MATERIAL"));
            table.HorizontalAlignment = 2;
            var allData = model.GetAllValues();
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("No."));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Name"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Length (mm)"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Quantity"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            // No 1.
            cell = new PdfPCell(new Phrase("1"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Shaft Ø{0}", allData["X13"]));
            int value = Nearest5(allData["A3"]);
            cell = new PdfPCell(new Phrase(value.ToString()));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("01"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // No 2
            cell = new PdfPCell(new Phrase("2"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Roller pipe Ø{0} x {1}", allData["D"], allData["t"]));
            value = Nearest5(allData["L"]);
            cell = new PdfPCell(new Phrase(value.ToString()));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("01"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // No 3
            cell = new PdfPCell(new Phrase("3"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Bearing stand {0}-{1}", allData["Bearing"], allData["D"]));
            cell = new PdfPCell(new Phrase(""));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("02"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // No 4
            cell = new PdfPCell(new Phrase("4"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Bearing {0}", allData["Bearing"]));
            cell = new PdfPCell(new Phrase(""));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("02"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // No 5
            cell = new PdfPCell(new Phrase("5"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Seal for bearing {0}", allData["Bearing"]));
            cell = new PdfPCell(new Phrase(""));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("02"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // No 6
            cell = new PdfPCell(new Phrase("6"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(string.Format("Circlip for shaft Ø{0}", allData["d1"]));
            cell = new PdfPCell(new Phrase(""));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("02"));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            //table.WidthPercentage = 50.0f;

            table.SetTotalWidth(new float[] { 25f, 200f, 80f, 50f });
            float h = table.TotalHeight;

            table.WriteSelectedRows(0, -1, 14, h + 14, writer.DirectContent);
            return table.TotalHeight;
        }

        public static int Nearest5(object value) {
            if (value == null) {
                return 0;
            }
            var f = Convert.ToInt32((float)value);
            int i = f + 1;
            for (i = f + 1; i < f + 5; i++) {
                if (i % 5 == 0) {
                    return i;
                }
            }
            return i;
        }
    }
}
