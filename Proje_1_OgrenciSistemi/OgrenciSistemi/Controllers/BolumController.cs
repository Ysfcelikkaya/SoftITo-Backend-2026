using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;

namespace OgrenciSistemi.Controllers
{
    public class BolumController : Controller
    {
            public readonly ApplicationDbContext dbcontext;
            public BolumController(ApplicationDbContext dbcontext)
            { this.dbcontext = dbcontext; }
            public IActionResult Index()
            {
                var result = dbcontext.Bolums.ToList();
                return View(result);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Bolum bolum)
            {
                dbcontext.Bolums.Add(bolum);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Edit(int id)
            {
                var result = dbcontext.Bolums.Find(id);
                return View(result);
            }
            [HttpPost]
            public IActionResult Edit(Bolum bolum)
            {
                dbcontext.Update(bolum);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                var result = dbcontext.Bolums.Find(id);
                return View(result);
            }
            [HttpPost]
            public IActionResult Delete(Bolum bolum)
            {
                dbcontext.Remove(bolum);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

