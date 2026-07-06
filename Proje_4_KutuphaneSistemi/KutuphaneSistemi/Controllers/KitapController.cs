using Kutuphane.Data.Data;
using Kutuphane.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KutuphaneSistemi.Controllers
{
    public class KitapController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public KitapController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var kitaplarSorgusu = from k in dbcontext.Kitaps select k;

            if (!string.IsNullOrEmpty(searchString))
            {
                kitaplarSorgusu = kitaplarSorgusu.Where(k => k.KitapAdi.Contains(searchString));
            }
            var result = kitaplarSorgusu.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi");
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kitap kitap)
        {
            ModelState.Remove("Kategori");
            ModelState.Remove("Yazar");

            if (ModelState.IsValid)
            {
                dbcontext.Kitaps.Add(kitap);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi", kitap.KategoriNo);
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi", kitap.YazarNo);

            return View(kitap);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = dbcontext.Kitaps.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi", kitap.KategoriNo);
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi", kitap.YazarNo);

            return View(kitap);
        }
        [HttpPost]
        public IActionResult Edit(Kitap kitap)
        {
            ModelState.Remove("Kategori");
            ModelState.Remove("Yazar");

            if (ModelState.IsValid)
            {
                dbcontext.Kitaps.Update(kitap);
                dbcontext.SaveChanges();
                return RedirectToAction("Index"); // Başarılıysa Index'e döner
            }

            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi", kitap.KategoriNo);
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi", kitap.YazarNo);

            return View(kitap);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = dbcontext.Kitaps.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi");
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi");
            return View(kitap);
        }
        [HttpPost]
        public IActionResult Delete(Kitap kitap)
        {
            ModelState.Remove("Kategori");
            ModelState.Remove("Yazar");

            if (ModelState.IsValid)
            {
                dbcontext.Kitaps.Remove(kitap);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["KategoriNo"] = new SelectList(dbcontext.Kategoris, "KategoriNo", "KategoriAdi", kitap.KategoriNo);
            ViewData["YazarNo"] = new SelectList(dbcontext.Yazars, "YazarNo", "YazarAdi", kitap.YazarNo);

            return View(kitap);
        }
        public IActionResult ExportToPdf()
        {
            var kitaplar = dbcontext.Kitaps.ToList();
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));
                    page.Header()
                        .Text("Kitap Listesi Raporu")
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
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Kitap Adı").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Kitap Sayısı").Bold();
                            });
                            foreach (var item in kitaplar)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.KitapNo.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.KitapAdi);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.KitapSayisi.ToString());
                            }
                        });
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span($"Toplam Kayıt: {kitaplar.Count} | Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });
            var pdfBytes = pdfDocument.GeneratePdf();

            return File(
                pdfBytes,
                "application/pdf",
                $"Kitap_Listesi_{DateTime.Now:yyyyMMdd}.pdf");

        }
        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Backend softito");
            var products = dbcontext.Kitaps.ToList();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Kitap Listesi");
                worksheet.Cells[1, 1].Value = "Kitap ID";
                worksheet.Cells[1, 2].Value = "Kitap Adı";
                worksheet.Cells[1, 3].Value = "Kitap Sayisi";

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
                    worksheet.Cells[rowNumber, 1].Value = item.KitapNo;
                    worksheet.Cells[rowNumber, 2].Value = item.KitapAdi;
                    worksheet.Cells[rowNumber, 3].Value = item.KitapSayisi;



                    rowNumber++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();
                string fileName = $"Kitap_Listesi_{DateTime.Now:yyyyMMdd}.xlsx";

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }

        }
    }
}
