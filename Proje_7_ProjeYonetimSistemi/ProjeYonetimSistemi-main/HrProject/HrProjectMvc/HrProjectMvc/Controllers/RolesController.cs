using HrProjectMvc.Data;
using HrProjectMvc.Filters;
using HrProjectMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrProjectMvc.Controllers
{
    [LoginCheck]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Roles role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var role = _context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(Roles role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var role = _context.Roles.Find(id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}