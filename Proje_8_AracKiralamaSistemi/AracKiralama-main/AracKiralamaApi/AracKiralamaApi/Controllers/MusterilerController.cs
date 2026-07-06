using AracKiralamaApi.Data;
using AracKiralamaApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracKiralamaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterilerController : ControllerBase
    {
        private readonly DapperContext dbcontext;

        public MusterilerController(DapperContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetMusteriler")]
        public async Task<IEnumerable<Musteri>> GetMusteriler()
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryAsync<Musteri>(
                "GetMusteriler",
                commandType: CommandType.StoredProcedure);
        }

        [HttpGet]
        [Route("GetMusteriById/{id}")]
        public async Task<Musteri> GetMusteriById(int id)
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Musteri>(
                "GetMusteriById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        [HttpPost]
        [Route("AddMusteri")]
        public async Task<Musteri> AddMusteri(Musteri musteri)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "AddMusteri",
                new { musteri.AdSoyad, musteri.Telefon, musteri.EhliyetNo },
                commandType: CommandType.StoredProcedure);

            return musteri;
        }

        [HttpPut]
        [Route("UpdateMusteri")]
        public async Task<Musteri> UpdateMusteri(Musteri musteri)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "UpdateMusteri",
                new
                {
                    musteri.Id,
                    musteri.AdSoyad,
                    musteri.Telefon,
                    musteri.EhliyetNo
                },
                commandType: CommandType.StoredProcedure);

            return musteri;
        }

        [HttpDelete]
        [Route("DeleteMusteri/{id}")]
        public async Task<bool> DeleteMusteri(int id)
        {
            using var connection = dbcontext.CreateConnection();

            var result = await connection.ExecuteAsync(
                "DeleteMusteri",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}