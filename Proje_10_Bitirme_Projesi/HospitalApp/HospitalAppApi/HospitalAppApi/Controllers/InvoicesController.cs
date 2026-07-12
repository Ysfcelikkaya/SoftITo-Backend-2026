using HospitalAppApi.Data;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Giriş (Login) şart!
    public class InvoicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= 1. KİŞİYE ÖZEL FATURALARI GETİR (GET) =================
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            IQueryable<Invoice> query = _context.Invoices
                .Include(i => i.Appointment).ThenInclude(a => a.Patient)
                .Include(i => i.Admission).ThenInclude(ad => ad.Patient); // Yatışları da dahil et!

            if (role == "Patient" && !string.IsNullOrEmpty(userIdStr))
            {
                int userId = int.Parse(userIdStr);
                query = query.Where(i =>
                    (i.Appointment != null && i.Appointment.Patient != null && i.Appointment.Patient.UserId == userId) ||
                    (i.Admission != null && i.Admission.Patient != null && i.Admission.Patient.UserId == userId)
                );
            }

            var invoices = await query.ToListAsync();

            var result = invoices.Select(i => new
            {
                Id = i.Id,
                IssueDate = i.IssueDate,
                Amount = i.Amount,
                Status = i.Status,
                PatientName = i.Appointment != null ? i.Appointment.Patient.FirstName + " " + i.Appointment.Patient.LastName
                            : i.Admission != null ? i.Admission.Patient.FirstName + " " + i.Admission.Patient.LastName
                            : "Bilinmiyor"
            });

            return Ok(result);
        }
        // ================= 2. YENİ FATURA KES (POST) =================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (invoice == null || invoice.Amount <= 0) return BadRequest("Geçersiz fatura tutarı.");

            // Fatura tarihi şu an yapılıyor ve varsayılan olarak "Ödenmedi" (Unpaid) atanıyor
            invoice.IssueDate = DateTime.Now;
            invoice.Status = "Unpaid";

            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();

            return Ok("Fatura randevuya başarıyla yansıtıldı.");
        }

        // ================= 3. FATURAYI ÖDE (PUT) =================
        [HttpPut("pay/{id}")]
        public async Task<IActionResult> PayInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound("Fatura bulunamadı.");

            if (invoice.Status == "Paid") return BadRequest("Bu fatura zaten ödenmiş!");

            // Faturayı "Ödendi" yapıyoruz
            invoice.Status = "Paid";

            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();

            return Ok("Ödeme başarıyla alındı. Fatura kapatıldı.");
        }
    }
}