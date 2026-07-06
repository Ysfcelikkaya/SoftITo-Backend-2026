using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly Context _context;

        public AuthController(Context context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password,bool rememberMe)
        {
            var user = _context.Query<Customer>(
                "CustomerLogin",
                new { Email = email, Password = password }
            ).FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetInt32("CustomerId", user.CustomerId);
                HttpContext.Session.SetString("FullName", user.FullName);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login!";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, string phone, string password)
        {
            var param = new
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                Password = password
            };

            _context.Execute("CustomerRegister", param);

            return RedirectToAction("Login");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            var code = Guid.NewGuid()
                           .ToString()
                           .Substring(0, 6)
                           .ToUpper();

            _context.Execute(
                "CustomerSetResetCode",
                new
                {
                    Email = email,
                    Code = code
                });

            ViewBag.Code = code;

            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(
            string email,
            string code,
            string password)
        {
            _context.Execute(
                "CustomerResetPassword",
                new
                {
                    Email = email,
                    Code = code,
                    Password = password
                });

            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}