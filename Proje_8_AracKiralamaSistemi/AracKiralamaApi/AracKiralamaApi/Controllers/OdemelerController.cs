using AracKiralamaApi.Data;
using AracKiralamaApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracKiralamaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemelerController : ControllerBase
    {
        private readonly DapperContext dbcontext;

        public OdemelerController(DapperContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetOdemeler")]
        public async Task<IEnumerable<object>> GetOdemeler()
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryAsync<object>(
                "GetOdemeler",
                commandType: CommandType.StoredProcedure);
        }

        [HttpGet]
        [Route("GetOdemeById/{id}")]
        public async Task<object> GetOdemeById(int id)
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<object>(
                "GetOdemeById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        
        [HttpPost]
        [Route("AddOdeme")]
        public async Task<Odeme> AddOdeme(Odeme odeme)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "AddOdeme",
                new
                {
                    odeme.KiralamaId,
                    odeme.Tutar,
                    odeme.OdemeTarihi
                },
                commandType: CommandType.StoredProcedure);

            return odeme;
        }

        [HttpDelete]
        [Route("DeleteOdeme/{id}")]
        public async Task<bool> DeleteOdeme(int id)
        {
            using var connection = dbcontext.CreateConnection();

            var result = await connection.ExecuteAsync(
                "DeleteOdeme",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}