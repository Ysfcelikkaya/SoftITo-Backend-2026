using HospitalAppApi.Data;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 1. KAPI: Giriş (Login) yapmayan kimse bu sokağa giremez!
    public class AdmissionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= 1. KİŞİYE ÖZEL YATIŞLARI GETİR (GET) =================
        [HttpGet]
        public async Task<IActionResult> GetAllAdmissions()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            IQueryable<Admission> query = _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Room);

            // SADECE HASTALARI KISITLIYORUZ (Kendi yatışını görsün)
            if (role == "Patient" && !string.IsNullOrEmpty(userIdStr))
            {
                int userId = int.Parse(userIdStr);
                query = query.Where(a => a.Patient != null && a.Patient.UserId == userId);
            }

            var admissions = await query.ToListAsync();

            var result = admissions.Select(a => new
            {
                Id = a.Id,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,
                PatientName = a.Patient != null ? a.Patient.FirstName + " " + a.Patient.LastName : "Bilinmiyor",
                RoomNumber = a.Room != null ? a.Room.RoomNumber : "Bilinmiyor",
                IsActive = a.DischargeDate == null
            });

            return Ok(result);
        }

        // ================= 2. YENİ YATIŞ YAP (POST) =================
        [Authorize(Roles = "Admin, Doktor")]
        [HttpPost]
        public async Task<IActionResult> CreateAdmission([FromBody] Admission admission)
        {
            if (admission == null) return BadRequest("Hatalı veri.");

            admission.AdmissionDate = DateTime.Now;

            // Odanın durumunu Dolu (isOccupied = true) yapıyoruz
            var room = await _context.Rooms.FindAsync(admission.RoomId);
            if (room != null)
            {
                room.IsOccupied = true;
            }

            await _context.Admissions.AddAsync(admission);
            await _context.SaveChangesAsync();

            return Ok("Hasta odaya başarıyla yatırıldı.");
        }

        // ================= 3. HASTAYI TABURCU ET (PUT) =================
        [Authorize(Roles = "Admin, Doktor")]
        [HttpPut("discharge/{id}")]
        public async Task<IActionResult> DischargePatient(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null) return NotFound("Yatış bulunamadı.");

            admission.DischargeDate = DateTime.Now;

            // Kaldığı odayı tekrar "Boş" durumuna getiriyoruz
            var room = await _context.Rooms.FindAsync(admission.RoomId);
            if (room != null)
            {
                room.IsOccupied = false;
            }

            _context.Admissions.Update(admission);
            await _context.SaveChangesAsync();

            return Ok("Hasta taburcu edildi ve oda boşaltıldı.");
        }
    }
}