using Microsoft.AspNetCore.Mvc;
using HrProjectMvc.Data;
using HrProjectMvc.Models;
using HrProjectMvc.Models.ViewModels;

namespace HrProjectMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.UserName == model.UserName
                                  && x.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("RoleId", user.RoleId.ToString());

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View(model);
        }

        public IActionResult Register()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string userName, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);

            if (user != null)
            {
                user.Password = newPassword;
                _context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}