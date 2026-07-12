using Microsoft.AspNetCore.Mvc;

namespace HospitalAppMvc.Controllers
{
    public class LandingController : Controller
    {
        // Herkesin girebilmesi için [Authorize] yazmıyoruz!
        public IActionResult Index()
        {
            return View();
        }
    }
}