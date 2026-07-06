using HrProjectMvc.Data;
using HrProjectMvc.Filters;
using HrProjectMvc.Migrations;
using HrProjectMvc.Models;
using HrProjectMvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
//using System.Reflection.Metadata;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DrawingColor = System.Drawing.Color;


namespace HrProjectMvc.Controllers
{
    // [Authorize]
    [LoginCheck]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Roles = _context.Roles.ToList();
            var user = _context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UserRoleReport(int? roleId)
        {
            var roles = _context.Roles.ToList();
            ViewBag.Roles = roles;

            var query = from u in _context.Users
                        join r in _context.Roles
                        on u.RoleId equals r.RoleId
                        select new UserRoleViewModel
                        {
                            UserId = u.UserId,
                            UserName = u.UserName,
                            RoleName = r.RoleName,
                            RoleId = r.RoleId
                        };

            if (roleId != null)
            {
                query = query.Where(x => x.RoleId == roleId);
            }

            return View(query.ToList());
        }
        public IActionResult ExportUsersToPdf()
        {
            var users = (from u in _context.Users
                         join r in _context.Roles
                         on u.RoleId equals r.RoleId
                         select new UserRoleViewModel
                         {
                             UserId = u.UserId,
                             UserName = u.UserName,
                             RoleName = r.RoleName
                         }).ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .Text("User - Role Report")
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
                                columns.RelativeColumn();    
                            });


                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("ID").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("User Name").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Role").Bold();
                            });
                            foreach (var item in users)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5)
                                    .Text(item.UserId.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5)
                                    .Text(item.UserName);

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5)
                                    .Text(item.RoleName);
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var bytes = pdf.GeneratePdf();
            return File(bytes, "application/pdf", $"Users_Role_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportUsersToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Backend softito");

            var users = (from u in _context.Users
                         join r in _context.Roles
                         on u.RoleId equals r.RoleId
                         select new UserRoleViewModel
                         {
                             UserId = u.UserId,
                             UserName = u.UserName,
                             RoleName = r.RoleName
                         }).ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("User Role Report");

                worksheet.Cells[1, 1].Value = "User ID";
                worksheet.Cells[1, 2].Value = "User Name";
                worksheet.Cells[1, 3].Value = "Role Name";

                using (var range = worksheet.Cells[1, 1, 1, 3])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(DrawingColor.DarkBlue);
                    range.Style.Font.Color.SetColor(DrawingColor.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }


                int row = 2;

                foreach (var item in users)
                {
                    worksheet.Cells[row, 1].Value = item.UserId;
                    worksheet.Cells[row, 2].Value = item.UserName;
                    worksheet.Cells[row, 3].Value = item.RoleName;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();
                string fileName = $"Users_Roles_{DateTime.Now:yyyyMMdd}.xlsx";

                return File(fileBytes,  
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName);
            }
        }
    }
}

