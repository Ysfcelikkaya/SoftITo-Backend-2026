using Kutuphane.Data;      
using Kutuphane.Model;     
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Kutuphane.Web.Controllers
{
    public class AccountController : Controller
    {
        // GİRİŞ SAYFASINI AÇAN METOT
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // GİRİŞ BUTONUNA BASILINCA ÇALIŞAN METOT
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var kullanici = StaticUserDatabase.Kullanicilar
                .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (kullanici != null)
            {
                // Başarılıysa Home Controller'ın Index'ine yönlendir (Ana Sayfa)
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre!";
            return View(model);
        }

        // KAYIT SAYFASINI AÇAN METOT
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // KAYIT BUTONUNA BASILINCA ÇALIŞAN METOT
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.AdSoyad))
            {
                ViewBag.Message = "Lütfen tüm alanları doldurun.";
                return View(model);
            }

            if (StaticUserDatabase.Kullanicilar.Any(x => x.Username?.ToLower() == model.Username.ToLower()))
            {
                ViewBag.Message = "Bu kullanıcı adı zaten alınmış!";
                return View(model);
            }

            var yeniKullanici = new Kullanici
            {
                Id = Guid.NewGuid().ToString(),
                AdSoyad = model.AdSoyad,
                Username = model.Username,
                Password = model.Password
            };

            StaticUserDatabase.Kullanicilar.Add(yeniKullanici);

            // Başarılıysa Login'e geri gönder
            return RedirectToAction("Login", "Account");
        }
    }
}