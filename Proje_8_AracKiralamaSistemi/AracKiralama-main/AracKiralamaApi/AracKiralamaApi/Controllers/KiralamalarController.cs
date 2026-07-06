using AracKiralamaApi.Data;
using AracKiralamaApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracKiralamaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiralamalarController : ControllerBase
    {
        private readonly DapperContext dbcontext;

        public KiralamalarController(DapperContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetKiralamalar")]
        public async Task<IEnumerable<object>> GetKiralamalar()
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryAsync<object>(
                "GetKiralamalar",
                commandType: CommandType.StoredProcedure);
        }

        [HttpGet]
        [Route("GetKiralamaById/{id}")]
        public async Task<object> GetKiralamaById(int id)
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<object>(
                "GetKiralamaById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        
        [HttpPost]
        [Route("AddKiralama")]
        public async Task<Kiralama> AddKiralama(Kiralama kiralama)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "AddKiralama",
                new
                {
                    kiralama.AracId,
                    kiralama.MusteriId,
                    kiralama.BaslangicTarih,
                    kiralama.BitisTarih
                },
                commandType: CommandType.StoredProcedure);

            return kiralama;
        }
        [HttpDelete]
        [Route("DeleteKiralama/{id}")]
        public async Task<bool> DeleteKiralama(int id)
        {
            using var connection = dbcontext.CreateConnection();

            var result = await connection.ExecuteAsync(
                "DeleteKiralama",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}