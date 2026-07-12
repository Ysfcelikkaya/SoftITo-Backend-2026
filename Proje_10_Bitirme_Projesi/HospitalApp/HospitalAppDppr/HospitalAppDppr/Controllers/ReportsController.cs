using ClosedXML.Excel;
using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly DapperContext _context;

        public ReportsController(DapperContext context)
        {
            _context = context;
        }

        // ==========================================
        // 1. EXCEL ÇIKTISI ALMA (CLOSEDXML)
        // ==========================================
        [HttpGet("ExportPatientsToExcel")]
        public async Task<IActionResult> ExportPatientsToExcel()
        {
            IEnumerable<PatientReadModel> patients;

            // DapperContext ve SP ile veriyi çekiyoruz (Çok Güvenli ve Hızlı)
            using (var connection = _context.CreateConnection())
            {
                patients = await connection.QueryAsync<PatientReadModel>("SP_GetAllPatients", commandType: CommandType.StoredProcedure);
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hasta Listesi");

                // Başlıklar
                worksheet.Cell(1, 1).Value = "TC Kimlik No";
                worksheet.Cell(1, 2).Value = "Ad";
                worksheet.Cell(1, 3).Value = "Soyad";
                worksheet.Cell(1, 4).Value = "Kan Grubu";

                worksheet.Range("A1:D1").Style.Font.Bold = true;
                worksheet.Range("A1:D1").Style.Fill.BackgroundColor = XLColor.LightGray;

                // Veriler
                int row = 2;
                foreach (var patient in patients)
                {
                    worksheet.Cell(row, 1).Value = patient.IdentityNumber;
                    worksheet.Cell(row, 2).Value = patient.FirstName;
                    worksheet.Cell(row, 3).Value = patient.LastName;
                    worksheet.Cell(row, 4).Value = patient.BloodGroup;
                    row++;
                }
                worksheet.Columns().AdjustToContents();

                // Dosyayı oluştur ve fırlat
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HastaRaporu.xlsx");
                }
            }
        }

        // ==========================================
        // 2. PDF ÇIKTISI ALMA (QUESTPDF)
        // ==========================================
        [HttpGet("ExportPatientsToPdf")]
        public async Task<IActionResult> ExportPatientsToPdf()
        {
            QuestPDF.Settings.License = LicenseType.Community; // Ücretsiz sürüm

            IEnumerable<PatientReadModel> patients;

            // DapperContext ve SP ile veriyi çekiyoruz
            using (var connection = _context.CreateConnection())
            {
                patients = await connection.QueryAsync<PatientReadModel>("SP_GetAllPatients", commandType: CommandType.StoredProcedure);
            }

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("Hastane Sistemi - Hasta Raporu")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(); columns.RelativeColumn();
                            columns.RelativeColumn(); columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().BorderBottom(1).Padding(2).Text("TC Kimlik").SemiBold();
                            header.Cell().BorderBottom(1).Padding(2).Text("Ad").SemiBold();
                            header.Cell().BorderBottom(1).Padding(2).Text("Soyad").SemiBold();
                            header.Cell().BorderBottom(1).Padding(2).Text("Kan Grubu").SemiBold();
                        });

                        foreach (var patient in patients)
                        {
                            // Artık dynamic kullanmadığımız için ToString() gibi hilelere gerek yok! 
                            // PatientReadModel olduğu için .Text() direkt string olarak algılar.
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(patient.IdentityNumber);
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(patient.FirstName);
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(patient.LastName);
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(patient.BloodGroup);
                        }
                    });

                    page.Footer().AlignCenter().Text(x => { x.Span("Sayfa "); x.CurrentPageNumber(); });
                });
            });

            return File(document.GeneratePdf(), "application/pdf", "HastaRaporu.pdf");
        }
    }
}