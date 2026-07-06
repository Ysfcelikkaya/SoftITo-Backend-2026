using EmlakProjectORM.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Index(string username, string password)
        {
            var admin = _unitOfWork.AdminUser.GetFirstOrDefault(x => x.Username == username && x.Password == password);

            if (admin != null)
            {
                return RedirectToAction("Index", "Property", new { area = "Admin" });
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }
    }
}