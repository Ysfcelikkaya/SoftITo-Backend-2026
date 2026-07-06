using AracKiralamaApi.Data;
using AracKiralamaApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracKiralamaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AraclarController : ControllerBase
    {
        private readonly DapperContext dbcontext;

        public AraclarController(DapperContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetAraclar")]
        public async Task<IEnumerable<Arac>> GetAraclar()
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryAsync<Arac>(
                "GetAraclar",
                commandType: CommandType.StoredProcedure);
        }

        [HttpGet]
        [Route("GetAracById/{id}")]
        public async Task<Arac> GetAracById(int id)
        {
            using var connection = dbcontext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Arac>(
                "GetAracById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        [HttpPost]
        [Route("AddArac")]
        public async Task<ActionResult<Arac>> AddArac(Arac arac)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "AddArac",
                new
                {
                    arac.Marka,
                    arac.Model,
                    arac.Yil,
                    arac.GunlukUcret
                },
                commandType: CommandType.StoredProcedure);

            return arac;
        }

        [HttpPut]
        [Route("UpdateArac")]
        public async Task<ActionResult<Arac>> UpdateArac(Arac arac)
        {
            using var connection = dbcontext.CreateConnection();

            await connection.ExecuteAsync(
                "UpdateArac",
                new
                {
                    arac.Id,
                    arac.Marka,
                    arac.Model,
                    arac.Yil,
                    arac.GunlukUcret
                },
                commandType: CommandType.StoredProcedure);

            return arac;
        }

        [HttpDelete]
        [Route("DeleteArac/{id}")]
        public async Task<bool> DeleteArac(int id)
        {
            using var connection = dbcontext.CreateConnection();

            var result = await connection.ExecuteAsync(
                "DeleteArac",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}