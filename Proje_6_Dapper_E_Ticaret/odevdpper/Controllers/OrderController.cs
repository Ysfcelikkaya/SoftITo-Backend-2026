using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly Context _context;

        public OrderController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Query<Order>("OrderViewAll");
            return View(values);
        }

        public IActionResult EY(int id = 0)
        {
            ViewBag.customers = _context.Query<Customer>("CustomerViewAll");
            ViewBag.products = _context.Query<Product>("ProductViewAll");

            return View();
        }

        [HttpPost]
        public IActionResult EY(Order order)
        {
            var param = new
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity
            };

            _context.Execute("OrderEY", param);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Execute("OrderDelete", new { OrderId = id });
            return RedirectToAction("Index");
        }
    }
}