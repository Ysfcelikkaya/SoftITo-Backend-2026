using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace odevrzrpg.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Message = "Lütfen tüm alanları doldurun.";
                return Page();
            }

            // Kullanıcı adı daha önce alınmış mı kontrolü (küçük/büyük harfe duyarsız)
            if (StaticUserDatabase.Kullanicilar.Any(x => x.Username?.ToLower() == Username.ToLower()))
            {
                Message = "Bu kullanıcı adı zaten alınmış!";
                return Page();
            }

            var yeniKullanici = new Kullanici
            {
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = Password
            };

            StaticUserDatabase.Kullanicilar.Add(yeniKullanici);

            // Başarılı kayıttan sonra Login'e yönlendir (Account klasörü içinde olduğu için)
            return RedirectToPage("/Account/Login");
        }
    }

    // ORTAK HAFIZA VERİTABANI
    public static class StaticUserDatabase
    {
        public static List<Kullanici> Kullanicilar = new List<Kullanici>()
        {
            new Kullanici { Id = "1", Username = "admin", Password = "123" }
        };
    }
}