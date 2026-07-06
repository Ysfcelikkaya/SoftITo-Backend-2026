using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace OgrenciSistemi.Controllers
{
    public class OgretmenController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public OgretmenController(ApplicationDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        public IActionResult Index()
        {
            var result = dbcontext.Ogretmens.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ogretmen ogretmen)
        {
            dbcontext.Ogretmens.Add(ogretmen);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Ogretmens.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Ogretmen ogretmen)
        {
            dbcontext.Update(ogretmen);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Ogretmens.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Ogretmen ogretmen)
        {
            dbcontext.Remove(ogretmen);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
