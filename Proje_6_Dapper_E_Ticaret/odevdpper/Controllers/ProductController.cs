using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var products = _context.Query<Product>("ProductViewAll");

            if (!string.IsNullOrEmpty(search))
            {
                products = products
                    .Where(x => x.ProductName.ToLower()
                    .Contains(search.ToLower()));
            }

            return View(products);
        }

        public IActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();

            var value = _context
                .Query<Product>("ProductViewById", new { ProductId = id })
                .FirstOrDefault();

            return View(value);
        }

        [HttpPost]
        public IActionResult EY(Product product)
        {
            _context.Execute("ProductEY", product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Execute("ProductDelete", new { ProductId = id });
            return RedirectToAction("Index");
        }
    }
}