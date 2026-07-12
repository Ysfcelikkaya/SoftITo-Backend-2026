using Dapper;
using HospitalAppDppr.Context;
using HospitalAppDppr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAppDppr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesReadController : ControllerBase
    {
        private readonly DapperContext _context;

        public InvoicesReadController(DapperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            using (var connection = _context.CreateConnection())
            {
                var invoices = await connection.QueryAsync<InvoiceReadModel>(
                    "SP_GetAllInvoices",
                    commandType: CommandType.StoredProcedure);

                return Ok(invoices);
            }
        }
    }
}