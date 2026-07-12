using HospitalAppApi.Data;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicalRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            IQueryable<MedicalRecord> query = _context.MedicalRecords
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Doctor);

            // Giren kişi hastaysa sadece KENDİ kayıtlarını görsün!
            if (role == "Patient" && !string.IsNullOrEmpty(userIdStr))
            {
                int userId = int.Parse(userIdStr);
                query = query.Where(m => m.Appointment != null && m.Appointment.Patient != null && m.Appointment.Patient.UserId == userId);
            }

            var records = await query.ToListAsync();

            // YENİ EKLENEN ALANLAR BURAYA DAHİL EDİLDİ
            var result = records.Select(m => new
            {
                Id = m.Id,
                Diagnosis = m.Diagnosis,
                Prescription = m.Prescription,
                Medicines = m.Medicines,
                LabAndXRayResults = m.LabAndXRayResults,
                ReportDate = m.ReportDate,
                Notes = m.Notes,
                RecordDate = m.Appointment != null ? m.Appointment.AppointmentDate : DateTime.MinValue,
                PatientName = (m.Appointment != null && m.Appointment.Patient != null) ? m.Appointment.Patient.FirstName + " " + m.Appointment.Patient.LastName : "Bilinmiyor",
                DoctorName = (m.Appointment != null && m.Appointment.Doctor != null) ? "Dr. " + m.Appointment.Doctor.FirstName + " " + m.Appointment.Doctor.LastName : "Bilinmiyor"
            });

            return Ok(result);
        }

        [Authorize(Roles = "Admin, Doktor, Doctor")]
        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] MedicalRecord record)
        {
            if (record == null) return BadRequest("Hatalı veri.");

            await _context.MedicalRecords.AddAsync(record);
            await _context.SaveChangesAsync();

            return Ok("Tıbbi kayıt başarıyla oluşturuldu.");
        }
    }
}