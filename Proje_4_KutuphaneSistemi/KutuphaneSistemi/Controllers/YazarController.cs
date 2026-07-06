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
    public class YazarController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public YazarController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var result = dbcontext.Yazars.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Yazar yazar)
        {
            ModelState.Remove("Kitaps");
            if (ModelState.IsValid)
            {
                dbcontext.Yazars.Add(yazar);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazar);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var yazar = dbcontext.Yazars.Find(id);

            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        [HttpPost]
        public IActionResult Edit(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Yazars.Update(yazar);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazar);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var yazar = dbcontext.Yazars.Find(id);

            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var yazar = dbcontext.Yazars.Find(id);

            if (yazar != null)
            {
                dbcontext.Yazars.Remove(yazar);
                dbcontext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult ExportToPdf()
        {
            var Yazarlar = dbcontext.Yazars.ToList();

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                    page.Header()
                        .Text("Yazar Listesi Raporu")
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
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Yazar Adı").Bold();
                            });

                            foreach (var item in Yazarlar)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.YazarNo.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.YazarAdi);
                            }
                        });
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span($"Toplam Kayıt: {Yazarlar.Count} | Adet ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var pdfBytes = pdfDocument.GeneratePdf();

            return File(
                pdfBytes,
                "application/pdf",
                $"Yazar_Listesi_{DateTime.Now:yyyyMMdd}.pdf");

        }
        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Backend softito");
            var products = dbcontext.Yazars.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Yazar Listesi");

                worksheet.Cells[1, 1].Value = "Yazar ID";
                worksheet.Cells[1, 2].Value = "Yazar Adı";

                using (var range = worksheet.Cells[1, 1, 1, 2]) 
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
                    worksheet.Cells[rowNumber, 1].Value = item.YazarNo;
                    worksheet.Cells[rowNumber, 2].Value = item.YazarAdi;



                    rowNumber++;
                }



                //7.Sütun genişliklerini içeriğe göre otomatik ayarla

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // 8. Excel dosyasını byte dizisine çevirip tarayıcıya fırlat
                var fileBytes = package.GetAsByteArray();
                string fileName = $"Kitap_Listesi_{DateTime.Now:yyyyMMdd}.xlsx";

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
        }
    }
}