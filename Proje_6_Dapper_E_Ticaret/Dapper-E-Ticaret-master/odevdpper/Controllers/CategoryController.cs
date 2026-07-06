using DapperECommerce.Data;
using DapperECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Query<Category>("CategoryViewAll");
            return View(values);
        }

        public IActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();

            var value = _context
                .Query<Category>("CategoryViewById", new { CategoryId = id })
                .FirstOrDefault();

            return View(value);
        }

        [HttpPost]
        public IActionResult EY(Category category)
        {
            _context.Execute("CategoryEY", category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Execute("CategoryDelete", new { CategoryId = id });
            return RedirectToAction("Index");
        }
    }
}