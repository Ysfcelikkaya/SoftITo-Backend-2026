using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Context _context;

        public CustomerController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Query<Customer>("CustomerViewAll");
            return View(values);
        }

        public IActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();

            var value = _context
                .Query<Customer>("CustomerViewAll")
                .FirstOrDefault(x => x.CustomerId == id);

            return View(value);
        }

        [HttpPost]
        public IActionResult EY(Customer customer)
        {
            _context.Execute("CustomerEY", customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Execute("CustomerDelete", new { CustomerId = id });
            return RedirectToAction("Index");
        }
    }
}