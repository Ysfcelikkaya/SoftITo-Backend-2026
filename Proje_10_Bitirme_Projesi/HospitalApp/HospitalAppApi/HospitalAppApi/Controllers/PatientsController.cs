using HospitalAppApi.Data;
using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientsController> _logger;
        private readonly ApplicationDbContext _context;

        public PatientsController(IUnitOfWork unitOfWork, ILogger<PatientsController> logger, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _unitOfWork.Patient.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _unitOfWork.Patient.GetByIdAsync(id);
            if (patient == null) return NotFound("Bu ID'ye ait bir hasta bulunamadı.");
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

            // Eğer ekleyen kişi Admin DEĞİLSE (yani hasta kendi kayıt oluyorsa), kendi ID'sine zorla!
            if (role != "Admin" && role != "Yönetici")
            {
                patient.UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            }
            // Admin ekliyorsa patient.UserId formdan (combobox) gelen değer olarak kalır!

            await _unitOfWork.Patient.AddAsync(patient);
            await _unitOfWork.CommitAsync();
            _logger.LogInformation("YENİ KAYIT: {FirstName} {LastName} eklendi.", patient.FirstName, patient.LastName);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest("ID uyuşmazlığı.");

            var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
            if (role != "Admin" && role != "Yönetici")
            {
                patient.UserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            }

            _unitOfWork.Patient.Update(patient);
            await _unitOfWork.CommitAsync();
            return Ok("Hasta başarıyla güncellendi.");
        }

        // AKILLI SİLME METODU V2 (Yatışlar ve Faturalar dahil)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patientFromDb = await _unitOfWork.Patient.GetByIdAsync(id);
            if (patientFromDb == null) return NotFound("Hasta bulunamadı.");

            // KURAL 1: Aktif randevusu var mı?
            bool hasActiveAppointment = _context.Appointments.Any(a => a.PatientId == id && a.Status == "Pending");
            if (hasActiveAppointment)
            {
                return BadRequest("SİLİNEMEDİ: Bu hastanın henüz gerçekleşmemiş (Bekleyen) bir randevusu var! Lütfen önce o randevuyu iptal edin.");
            }

            // KURAL 2: Geçmiş randevuları, FATURALARI ve raporları bulup temizle
            var pastAppointments = _context.Appointments.Where(a => a.PatientId == id).ToList();
            foreach (var app in pastAppointments)
            {
                var records = _context.MedicalRecords.Where(m => m.AppointmentId == app.Id).ToList();
                if (records.Any()) _context.MedicalRecords.RemoveRange(records);

                var invoices = _context.Invoices.Where(i => i.AppointmentId == app.Id).ToList();
                if (invoices.Any()) _context.Invoices.RemoveRange(invoices);
            }
            if (pastAppointments.Any()) _context.Appointments.RemoveRange(pastAppointments);

            // KURAL 3: Hastanın "Yatış (Admission)" kayıtları varsa onları da temizle
            var admissions = _context.Admissions.Where(a => a.PatientId == id).ToList();
            if (admissions.Any()) _context.Admissions.RemoveRange(admissions);

            await _context.SaveChangesAsync();

            // KURAL 4: Bütün geçmişi temizlendi, şimdi hastayı uçur!
            _unitOfWork.Patient.Remove(patientFromDb);
            await _unitOfWork.CommitAsync();

            _logger.LogWarning("DİKKAT SİLİNME: {Id} ID'li hasta ve tüm geçmiş kayıtları silindi!", id);
            return Ok("Hasta ve tüm geçmiş kayıtları (Yatış, Fatura, Randevu, Rapor) sistemden pürüzsüzce silindi.");
        }
    }
}