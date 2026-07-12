using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public PatientsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            // SQL'de oluşturacağımız Stored Procedure'ün adı
            var procedureName = "SP_GetAllPatients";

            using (var connection = _context.CreateConnection())
            {
                var patients = await connection.QueryAsync<PatientReadModel>(
                    procedureName,
                    commandType: CommandType.StoredProcedure);

                return Ok(patients);
            }
        }
        [HttpGet("SearchPatientByName")]
        public async Task<IActionResult> SearchPatientByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("Lütfen bir isim girin.");

            using (var connection = _context.CreateConnection())
            {
                // Parametre (DynamicParameters) ile Dapper, gelen ismin güvenli olup olmadığını kontrol eder.
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name, DbType.String);

                var patients = await connection.QueryAsync<PatientReadModel>(
                    "SP_SearchPatientByName",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return Ok(patients);
            }
        }
    }
}