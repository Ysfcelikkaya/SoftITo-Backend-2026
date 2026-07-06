using AracKiralamaApi.Data;
using AracKiralamaApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracKiralamaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DapperContext dbcontext;

        public AuthController(DapperContext context)
        {
            dbcontext = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Kullanici k)
        {
            using var connection = dbcontext.CreateConnection();
            await connection.ExecuteAsync("RegisterKullanici",
                new { k.AdSoyad, k.Email, k.Sifre },
                commandType: CommandType.StoredProcedure);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Kullanici k)
        {
            using var connection = dbcontext.CreateConnection();
            var user = await connection.QueryFirstOrDefaultAsync<Kullanici>("LoginKullanici",
                new { k.Email, k.Sifre },
                commandType: CommandType.StoredProcedure);

            if (user != null)
                return Ok(user);
            else
                return BadRequest("Kullanıcı bulunamadı veya şifre hatalı");
        }
    }
}