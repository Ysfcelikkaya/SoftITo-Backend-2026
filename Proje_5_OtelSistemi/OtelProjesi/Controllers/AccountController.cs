using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OtelProjesi.Controllers
{
    public static class GeciciVeritabani
    {
        public static List<KullaniciBilgisi> Uyeler = new List<KullaniciBilgisi>()
        {
            new KullaniciBilgisi { Username = "admin", Password = "123" }
        };
    }

    public class KullaniciBilgisi
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var kullanici = GeciciVeritabani.Uyeler.FirstOrDefault(x => x.Username == Username && x.Password == Password);

            if (kullanici != null)
            {
                return RedirectToAction("Index", "Home"); 
            }

            ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre!";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string AdSoyad, string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ViewBag.Message = "Lütfen tüm alanları doldurun.";
                return View();
            }

            if (GeciciVeritabani.Uyeler.Any(x => x.Username == Username))
            {
                ViewBag.Message = "Bu kullanıcı adı zaten alınmış!";
                return View();
            }
            GeciciVeritabani.Uyeler.Add(new KullaniciBilgisi
            {
                Username = Username,
                Password = Password
            });

            return RedirectToAction("Login", "Account");
        }
    }
}