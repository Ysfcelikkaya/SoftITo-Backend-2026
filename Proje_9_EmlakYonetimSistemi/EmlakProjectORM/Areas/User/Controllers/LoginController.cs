using EmlakProjectORM.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var user = _unitOfWork.AppUser.GetFirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            ViewBag.Error = "Email adresi veya şifre hatalı!";
            return View();
        }
    }
}