using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public UsersReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserReadModel>(
                    "SP_GetAllUsers",
                    commandType: CommandType.StoredProcedure);

                return Ok(users);
            }
        }
    }
}