using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public MedicalRecordsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            using (var connection = _context.CreateConnection())
            {
                var records = await connection.QueryAsync<MedicalRecordReadModel>(
                    "SP_GetAllMedicalRecords",
                    commandType: CommandType.StoredProcedure);

                return Ok(records);
            }
        }
    }
}