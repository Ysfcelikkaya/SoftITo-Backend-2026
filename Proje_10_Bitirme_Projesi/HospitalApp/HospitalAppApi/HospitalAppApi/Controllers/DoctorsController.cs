using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Binaya girmek serbest
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 1. HERKES GÖREBİLİR (Kilit Yok)
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _unitOfWork.Doctor.GetAllAsync();
            return Ok(doctors);
        }

        // 2. TEK BİR DOKTORU GETİR (DÜZENLEME SAYFASINI AÇMAK İÇİN GEREKLİ!)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _unitOfWork.Doctor.GetByIdAsync(id);
            if (doctor == null) return NotFound("Doktor bulunamadı.");
            return Ok(doctor);
        }

        // 3. SADECE ADMİN YENİ DOKTOR EKLEYEBİLİR
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null) return BadRequest("Doktor bilgileri boş.");

            await _unitOfWork.Doctor.AddAsync(doctor);
            await _unitOfWork.CommitAsync();

            return Ok("Doktor başarıyla eklendi.");
        }

        // 4. SADECE ADMİN DOKTOR GÜNCELLEYEBİLİR (DÜZENLEMEK İÇİN GEREKLİ!)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id) return BadRequest("ID eşleşmiyor.");

            _unitOfWork.Doctor.Update(doctor);
            await _unitOfWork.CommitAsync();

            return Ok("Doktor başarıyla güncellendi.");
        }

        // 5. SADECE ADMİN DOKTOR SİLEBİLİR
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _unitOfWork.Doctor.GetByIdAsync(id);
            if (doctor == null) return NotFound();

            _unitOfWork.Doctor.Remove(doctor);
            await _unitOfWork.CommitAsync();

            return Ok("Doktor silindi.");
        }
    }
}