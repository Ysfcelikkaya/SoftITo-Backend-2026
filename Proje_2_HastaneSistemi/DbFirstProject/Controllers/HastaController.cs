using Microsoft.AspNetCore.Mvc;
using DbFirstProject.Models;

namespace DbFirstProject.Controllers
{
    public class HastaController : Controller
    {
        public readonly AppDbContext dbcontext;
        public HastaController(AppDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        public IActionResult Index()
        {
            var result = dbcontext.Hastas.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hasta hasta)
        {
            dbcontext.Hastas.Add(hasta);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Hastas.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Hasta hasta)
        {
            dbcontext.Update(hasta);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Hastas.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Hasta hasta)
        {
            dbcontext.Remove(hasta);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
