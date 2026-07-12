using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7150/");
        }

        // ================= LOGIN =================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    dynamic resultData = JsonConvert.DeserializeObject(resultString);
                    string token = resultData.token;
                    string rol = resultData.rol; // API'den gelen gerçek rol (Patient, Doctor, Admin)

                    // GÜVENLİK KAPISI: Seçtiği sekmeyle, veritabanındaki rolü eşleşiyor mu?
                    string translatedRole = rol.ToLower();
                    if (translatedRole == "patient") translatedRole = "hasta";
                    if (translatedRole == "doctor") translatedRole = "doktor"; // EKSİK OLAN KOD BURAYA EKLENDİ!

                    if (translatedRole != model.RequestedRole)
                    {
                        ViewBag.Error = $"Erişim Engellendi! Hesabınız '{rol}' yetkisine sahip. Lütfen doğru sekmeden giriş yapın.";
                        return View(model);
                    }

                    HttpContext.Session.SetString("JWToken", token);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Role, rol)
                    };
                    var identity = new ClaimsIdentity(claims, "CookieAuth");
                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                }
            }
            return View(model);
        }

        // ================= LOGOUT =================
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        // ================= REGISTER =================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string Username, string Email, string Password)
        {
            var requestData = new { Username, Email, Password };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Auth/Register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View();
            }
        }

        // ================= FORGOT PASSWORD =================
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Username, string NewPassword)
        {
            var requestData = new { Username, NewPassword };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Auth/ResetPassword", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Success = "Şifreniz başarıyla değiştirildi! Yeni şifrenizle giriş yapabilirsiniz.";
                return View();
            }
            else
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View();
            }
        }
    }
}