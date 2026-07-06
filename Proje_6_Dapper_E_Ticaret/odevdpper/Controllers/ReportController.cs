using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace DapperECommerce.Controllers
{
    public class ReportController : Controller
    {
        private readonly Context _context;

        public ReportController(Context context)
        {
            _context = context;
        }

        public IActionResult OrderReport(int? customerId, int? productId, int? categoryId, int sortType = 1)
        {
            ViewBag.Customers = _context.Query<Customer>("CustomerViewAll");
            ViewBag.Products = _context.Query<Product>("ProductViewAll");
            ViewBag.Categories = _context.Query<Category>("CategoryViewAll");

            var param = new
            {
                CustomerId = customerId,
                ProductId = productId,
                CategoryId = categoryId,
                SortType = sortType
            };

            var result = _context.Query<OrderReport>("ReportOrdersFiltered", param);

            return View(result);
        }
        public IActionResult ExportToPdf()
        {
            var orders = _context.Query<OrderReport>("ReportOrders");

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);

                    page.Header()
                        .Text("Order Report")
                        .SemiBold()
                        .FontSize(20);

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(70);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("Customer").Bold();
                                header.Cell().Text("Product").Bold();
                                header.Cell().Text("Category").Bold();
                                header.Cell().Text("Qty").Bold();
                            });

                            foreach (var item in orders)
                            {
                                table.Cell().Text(item.FullName);
                                table.Cell().Text(item.ProductName);
                                table.Cell().Text(item.CategoryName);
                                table.Cell().Text(item.Quantity.ToString());
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var pdfBytes = pdfDocument.GeneratePdf();

            return File(
                pdfBytes,
                "application/pdf",
                $"OrderReport_{DateTime.Now:yyyyMMdd}.pdf");
        }
        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("DapperECommerce");

            var orders = _context.Query<OrderReport>("ReportOrders");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Orders");

                worksheet.Cells[1, 1].Value = "Customer";
                worksheet.Cells[1, 2].Value = "Product";
                worksheet.Cells[1, 3].Value = "Category";
                worksheet.Cells[1, 4].Value = "Quantity";
                worksheet.Cells[1, 5].Value = "Date";

                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 2;

                foreach (var item in orders)
                {
                    worksheet.Cells[row, 1].Value = item.FullName;
                    worksheet.Cells[row, 2].Value = item.ProductName;
                    worksheet.Cells[row, 3].Value = item.CategoryName;
                    worksheet.Cells[row, 4].Value = item.Quantity;
                    worksheet.Cells[row, 5].Value = item.OrderDate;

                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();

                return File(
                    fileBytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"OrderReport_{DateTime.Now:yyyyMMdd}.xlsx");
            }
        }
    }
}