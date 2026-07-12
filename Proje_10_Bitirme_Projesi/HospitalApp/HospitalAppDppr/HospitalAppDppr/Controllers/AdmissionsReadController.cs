using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public AdmissionsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmissions()
        {
            using (var connection = _context.CreateConnection())
            {
                var admissions = await connection.QueryAsync<AdmissionReadModel>(
                    "SP_GetAllAdmissions",
                    commandType: CommandType.StoredProcedure);

                return Ok(admissions);
            }
        }
    }
}