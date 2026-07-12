using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public DepartmentsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            using (var connection = _context.CreateConnection())
            {
                var departments = await connection.QueryAsync<DepartmentReadModel>(
                    "SP_GetAllDepartments",
                    commandType: CommandType.StoredProcedure);

                return Ok(departments);
            }
        }
    }
}