using HospitalAppApi.Data;
using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public AppointmentsController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            IQueryable<Appointment> query = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor);

            if (role == "Patient" && !string.IsNullOrEmpty(userIdStr))
            {
                int userId = int.Parse(userIdStr);
                query = query.Where(a => a.Patient != null && a.Patient.UserId == userId);
            }
            else if ((role == "Doctor" || role == "Doktor") && !string.IsNullOrEmpty(userIdStr))
            {
                int userId = int.Parse(userIdStr);
                query = query.Where(a => a.Doctor != null && a.Doctor.UserId == userId);
            }

            var appointments = await query.ToListAsync();

            var result = appointments.Select(a => new
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                PatientName = a.Patient != null ? a.Patient.FirstName + " " + a.Patient.LastName : "Bilinmiyor",
                DoctorName = a.Doctor != null ? "Dr. " + a.Doctor.FirstName + " " + a.Doctor.LastName : "Bilinmiyor"
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null) return BadRequest("Geçersiz randevu bilgisi.");
            appointment.Status = "Pending";
            await _unitOfWork.Appointment.AddAsync(appointment);
            await _unitOfWork.CommitAsync();
            return Ok("Randevu başarıyla oluşturuldu.");
        }

        // HASTA'NIN İPTAL EDEBİLMESİ İÇİN ROLE EKLENDİ
        [Authorize(Roles = "Admin,Doktor,Doctor,Patient")]
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
        {
            var appointment = await _unitOfWork.Appointment.GetByIdAsync(id);
            if (appointment == null) return NotFound("Randevu bulunamadı.");

            appointment.Status = newStatus;
            _unitOfWork.Appointment.Update(appointment);
            await _unitOfWork.CommitAsync();

            return Ok($"Randevu durumu '{newStatus}' olarak güncellendi.");
        }
    }
}