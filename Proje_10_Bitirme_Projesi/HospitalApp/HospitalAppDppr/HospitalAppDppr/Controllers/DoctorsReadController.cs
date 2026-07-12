using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public DoctorsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            using (var connection = _context.CreateConnection())
            {
                var doctors = await connection.QueryAsync<DoctorReadModel>(
                    "SP_GetAllDoctors",
                    commandType: CommandType.StoredProcedure);

                return Ok(doctors);
            }
        }
    }
}