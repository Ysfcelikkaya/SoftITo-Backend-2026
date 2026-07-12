using HospitalAppApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Login ekranından bize gelecek olan küçük veri paketi (DTO)
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 1. Veritabanından Kullanıcıyı ve onun Rolünü (Admin mi, Doktor mu?) bul
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.PasswordHash == request.Password && u.IsActive == true);

            if (user == null)
                return Unauthorized("Kullanıcı adı veya şifre hatalı!");

            // 2. Kullanıcı bulunduysa, ona özel bir JWT (Kimlik Kartı) üret
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]);

            // Kartın üzerine yazılacak bilgiler (Claims)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.Name) // Hocanızın bahsettiği [Authorize(Roles="Doctor")] kilidini açacak sihirli bilgi burası!
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Kart 2 saat geçerli olsun
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // 3. Kartı kullanıcıya (Arayüze/MVC'ye) teslim et
            return Ok(new { Token = tokenString, Mesaj = "Giriş Başarılı!", Rol = user.Role.Name });
        }
        // Kayıt ekranından bize gelecek olan küçük veri paketi
        public class RegisterRequest
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // 1. Bu kullanıcı adı zaten var mı kontrol et
            var userExists = await _context.Users.AnyAsync(u => u.Username == request.Username);
            if (userExists)
                return BadRequest("Bu kullanıcı adı zaten alınmış!");

            // 2. Yeni kullanıcıyı otomatik kurallarla (SQL'e ihtiyaç duymadan) oluştur
            var newUser = new HospitalAppApi.Models.User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.Password, // Gerçek projelerde burası BCrypt ile şifrelenir
                IsActive = true,                 // OTOMATİK: Aktif olarak başlar
                RoleId = 2                       // OTOMATİK: Varsayılan olarak 2 (Hasta) rolü atanır
            };

            // 3. Veritabanına kaydet
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok("Kayıt işlemi başarıyla tamamlandı. Artık giriş yapabilirsiniz.");
        }
        // Şifre Sıfırlama Ekranından Gelecek İstek Kutusu (Artık Yeni Şifreyi de taşıyor)
        public class ResetPasswordRequest
        {
            public string Username { get; set; }
            public string NewPassword { get; set; }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                return BadRequest("Bu kullanıcı adına ait bir hesap bulunamadı!");

            // Kullanıcının sistemden gönderdiği KENDİ YENİ ŞİFRESİNİ veritabanına yazıyoruz
            user.PasswordHash = request.NewPassword;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Şifreniz başarıyla güncellendi!");
        }
    }
}