using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;
using System.Diagnostics;

namespace OgrenciSistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
