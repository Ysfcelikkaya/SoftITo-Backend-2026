using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace odevrzrpg.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var kullanici = StaticUserDatabase.Kullanicilar
                .FirstOrDefault(x => x.Username == Username && x.Password == Password);

            if (kullanici != null)
            {
                // Giriş başarılıysa sistemin ana sayfasına yönlendir
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Hatalı kullanıcı adı veya şifre!";
            return Page();
        }
    }
}