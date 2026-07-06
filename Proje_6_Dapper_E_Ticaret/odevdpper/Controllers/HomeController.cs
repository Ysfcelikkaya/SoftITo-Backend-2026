using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("FullName") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var categories = _context.Query<Category>("CategoryViewAll").Count();
            var products = _context.Query<Product>("ProductViewAll").Count();
            var customers = _context.Query<Customer>("CustomerViewAll").Count();
            var orders = _context.Query<Order>("OrderViewAll").Count();

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.Customers = customers;
            ViewBag.Orders = orders;

            return View();
        }
    }
}