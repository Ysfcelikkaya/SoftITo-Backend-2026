using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;

namespace OgrenciSistemi.Controllers
{
    public class DersController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public DersController(ApplicationDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        public IActionResult Index()
        {
            var result = dbcontext.Derss.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ders ders)
        {
            dbcontext.Derss.Add(ders);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Derss.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Ders ders)
        {
            dbcontext.Update(ders);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Derss.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Ders ders)
        {
            dbcontext.Remove(ders);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
