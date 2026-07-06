using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Areas.User.Controllers
{
    [Area("User")]
    public class RegisterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _unitOfWork.AppUser.GetFirstOrDefault(u => u.Email == appUser.Email);
                if (existingUser != null)
                {
                    ViewBag.Error = "Bu email adresi zaten kullanılıyor!";
                    return View(appUser);
                }

                _unitOfWork.AppUser.Add(appUser);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Login", new { area = "User" });
            }
            return View(appUser);
        }
    }
}