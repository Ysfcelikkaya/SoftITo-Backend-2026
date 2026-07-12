using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DapperContext _context;
        public DashboardController(DapperContext context) { _context = context; }

        [HttpGet("GetHospitalStatistics")]
        public async Task<IActionResult> GetHospitalStatistics()
        {
            var model = new DashboardReadModel();

            using (var connection = _context.CreateConnection())
            {
                // Dapper, veritabanına sadece 1 KERE gidip tam 4 farklı tabloyu sayıp gelecek!
                using (var multi = await connection.QueryMultipleAsync("SP_GetDashboardStats", commandType: CommandType.StoredProcedure))
                {
                    model.TotalPatients = await multi.ReadSingleAsync<int>();
                    model.TotalDoctors = await multi.ReadSingleAsync<int>();
                    model.TotalAppointments = await multi.ReadSingleAsync<int>();
                    model.TotalRevenue = await multi.ReadSingleOrDefaultAsync<decimal>(); // Yoksa 0 döner
                }
                return Ok(model);
            }
        }
    }
}