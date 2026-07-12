using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public RoomsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            using (var connection = _context.CreateConnection())
            {
                var rooms = await connection.QueryAsync<RoomReadModel>(
                    "SP_GetAllRooms",
                    commandType: CommandType.StoredProcedure);

                return Ok(rooms);
            }
        }
    }
}