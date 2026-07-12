using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models; // Kendi modeliniz kalacak
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public AppointmentsReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet] // DİKKAT: Metot artık MVC'den userId ve role bekliyor
        public async Task<IActionResult> GetAllAppointments(int userId, string role)
        {
            using (var connection = _context.CreateConnection())
            {
                // Stored Procedure'a (SQL'e) kuryenin getirdiği kimlikleri fırlatıyoruz!
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@Role", role);

                var appointments = await connection.QueryAsync<AppointmentReadModel>(
                    "SP_GetAllAppointments",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return Ok(appointments);
            }
        }
    }
}