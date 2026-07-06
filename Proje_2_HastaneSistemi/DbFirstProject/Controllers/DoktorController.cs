using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbFirstProject.Models;

namespace DbFirstProject.Controllers
{
    public class DoktorController : Controller
    {
        public readonly AppDbContext dbcontext;
        public DoktorController(AppDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        public IActionResult Index()
        {
            var result = dbcontext.Doktors.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doktor doktor)
        {
            dbcontext.Doktors.Add(doktor);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Doktors.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Doktor doktor)
        {
            dbcontext.Update(doktor);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Doktors.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Doktor doktor)
        {
            dbcontext.Remove(doktor);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
