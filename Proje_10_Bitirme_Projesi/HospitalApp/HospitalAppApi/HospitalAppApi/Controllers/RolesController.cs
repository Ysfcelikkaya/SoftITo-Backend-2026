using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolesController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Role.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            await _unitOfWork.Role.AddAsync(role);
            await _unitOfWork.CommitAsync();
            return Ok("Eklendi.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Role role)
        {
            if (id != role.Id) return BadRequest();
            _unitOfWork.Role.Update(role);
            await _unitOfWork.CommitAsync();
            return Ok("Güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.Role.GetByIdAsync(id);
            if (role == null) return NotFound();
            _unitOfWork.Role.Remove(role);
            await _unitOfWork.CommitAsync();
            return Ok("Silindi.");
        }
    }
}