using Microsoft.AspNetCore.Mvc;

namespace EmlakProjectORM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}