using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoomsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomsController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Room.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _unitOfWork.Room.GetByIdAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Room room)
        {
            await _unitOfWork.Room.AddAsync(room);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Room room)
        {
            if (id != room.Id) return BadRequest("ID uyuşmazlığı.");

            _unitOfWork.Room.Update(room);
            await _unitOfWork.CommitAsync();
            return Ok("Başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _unitOfWork.Room.GetByIdAsync(id);
            if (room == null) return NotFound("Bulunamadı.");

            _unitOfWork.Room.Remove(room);
            await _unitOfWork.CommitAsync();
            return Ok("Başarıyla silindi.");
        }
    }
}