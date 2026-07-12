using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Department.GetAllAsync());

        // ======= İŞTE BU EKSİKTİ (DÜZENLEME EKRANINA VERİ GETİRMEK İÇİN) =======
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dep = await _unitOfWork.Department.GetByIdAsync(id);
            if (dep == null) return NotFound();
            return Ok(dep);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department dep)
        {
            await _unitOfWork.Department.AddAsync(dep);
            await _unitOfWork.CommitAsync();
            return Ok("Eklendi.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department dep)
        {
            if (id != dep.Id) return BadRequest();
            _unitOfWork.Department.Update(dep);
            await _unitOfWork.CommitAsync();
            return Ok("Güncellendi.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await _unitOfWork.Department.GetByIdAsync(id);
            if (dep == null) return NotFound();
            _unitOfWork.Department.Remove(dep);
            await _unitOfWork.CommitAsync();
            return Ok("Silindi.");
        }
    }
}