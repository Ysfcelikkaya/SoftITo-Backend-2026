using Kutuphane.Data.Data;
using Kutuphane.Model;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KutuphaneSistemi.Controllers
{
    public class KategoriController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public KategoriController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var result = dbcontext.Kategoris.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            dbcontext.Kategoris.Add(kategori);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Kategoris.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            dbcontext.Update(kategori);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Kategoris.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            dbcontext.Remove(kategori);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ExportToPdf()
        {
            var kategoriler = dbcontext.Kategoris.ToList();
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));
                    page.Header()
                        .Text("Kategori Listesi Raporu")
                        .SemiBold()
                        .FontSize(20)
                        .FontColor(Colors.Blue.Medium);
                    page.Content()
                        .PaddingTop(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(60);
                                columns.RelativeColumn();
                                columns.ConstantColumn(100);
                            });
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("ID").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Kategori Adı").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Açıklama").Bold();
                            });
                            foreach (var item in kategoriler)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.KategoriNo.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.KategoriAdi);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Aciklama);
                            }
                        });
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span($"Toplam Kayıt: {kategoriler.Count} | Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });
            var pdfBytes = pdfDocument.GeneratePdf();

            return File(
                pdfBytes,
                "application/pdf",
                $"Kategori_Listesi_{DateTime.Now:yyyyMMdd}.pdf");

        }
        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Backend softito");
            var products = dbcontext.Kategoris.ToList();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Kategori Listesi");
                worksheet.Cells[1, 1].Value = "Kategori ID";
                worksheet.Cells[1, 2].Value = "Kategori Adı";
                worksheet.Cells[1, 3].Value = "Açıklama";

                using (var range = worksheet.Cells[1, 1, 1, 3])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(41, 128, 185));
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int rowNumber = 2;
                foreach (var item in products)
                {
                    worksheet.Cells[rowNumber, 1].Value = item.KategoriNo;
                    worksheet.Cells[rowNumber, 2].Value = item.KategoriAdi;
                    worksheet.Cells[rowNumber, 3].Value = item.Aciklama;



                    rowNumber++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();
                string fileName = $"Kategori_Listesi_{DateTime.Now:yyyyMMdd}.xlsx";

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }

        }
    }
}

