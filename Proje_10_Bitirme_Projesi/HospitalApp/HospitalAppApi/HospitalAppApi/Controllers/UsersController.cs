using HospitalAppApi.Data;
using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context; // Akıllı silme için eklendi

        public UsersController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null) return BadRequest();
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();
            return Ok("Kullanıcı güncellendi.");
        }

        // AKILLI DERİN SİLME (TÜM BAĞLARIYLA BİRLİKTE SİLER)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return NotFound("Kullanıcı bulunamadı.");

            // 1. Bu kullanıcıya ait Hasta (Patient) Profili var mı?
            var patient = _context.Patients.FirstOrDefault(p => p.UserId == id);
            if (patient != null)
            {
                bool hasActive = _context.Appointments.Any(a => a.PatientId == patient.Id && a.Status == "Pending");
                if (hasActive) return BadRequest("SİLİNEMEDİ: Bu kullanıcının BEKLEYEN (Aktif) bir hasta randevusu var!");

                var pastApps = _context.Appointments.Where(a => a.PatientId == patient.Id).ToList();
                foreach (var app in pastApps)
                {
                    var records = _context.MedicalRecords.Where(m => m.AppointmentId == app.Id).ToList();
                    if (records.Any()) _context.MedicalRecords.RemoveRange(records);

                    var invoices = _context.Invoices.Where(i => i.AppointmentId == app.Id).ToList();
                    if (invoices.Any()) _context.Invoices.RemoveRange(invoices);
                }
                if (pastApps.Any()) _context.Appointments.RemoveRange(pastApps);

                var admissions = _context.Admissions.Where(a => a.PatientId == patient.Id).ToList();
                if (admissions.Any()) _context.Admissions.RemoveRange(admissions);

                _unitOfWork.Patient.Remove(patient);
            }

            // 2. Bu kullanıcıya ait Doktor (Doctor) Profili var mı?
            var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == id);
            if (doctor != null)
            {
                bool hasActive = _context.Appointments.Any(a => a.DoctorId == doctor.Id && a.Status == "Pending");
                if (hasActive) return BadRequest("SİLİNEMEDİ: Bu doktorun BEKLEYEN (Aktif) hasta randevuları var!");

                var pastApps = _context.Appointments.Where(a => a.DoctorId == doctor.Id).ToList();
                foreach (var app in pastApps)
                {
                    var records = _context.MedicalRecords.Where(m => m.AppointmentId == app.Id).ToList();
                    if (records.Any()) _context.MedicalRecords.RemoveRange(records);

                    var invoices = _context.Invoices.Where(i => i.AppointmentId == app.Id).ToList();
                    if (invoices.Any()) _context.Invoices.RemoveRange(invoices);
                }
                if (pastApps.Any()) _context.Appointments.RemoveRange(pastApps);

                _unitOfWork.Doctor.Remove(doctor);
            }

            await _context.SaveChangesAsync(); // Bağları tamamen kopar

            // 3. En son kullanıcıyı uçur!
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();

            return Ok("Kullanıcı (ve varsa tüm hasta/doktor profilleri) sistemden tamamen silindi.");
        }
    }
}