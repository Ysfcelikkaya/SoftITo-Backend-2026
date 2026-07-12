using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public RolesReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            using (var connection = _context.CreateConnection())
            {
                var roles = await connection.QueryAsync<RoleReadModel>(
                    "SP_GetAllRoles",
                    commandType: CommandType.StoredProcedure);

                return Ok(roles);
            }
        }
    }
}