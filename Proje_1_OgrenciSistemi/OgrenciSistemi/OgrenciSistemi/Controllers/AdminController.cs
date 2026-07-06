using Microsoft.AspNetCore.Mvc;

namespace OgrenciSistemi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
