using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;
using Microsoft.EntityFrameworkCore;

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
            if (result == null)
            {
                return NotFound();
            }
                return View(result);
            }
            [HttpPost]
            public IActionResult Edit(int id,Bolum bolum)
            {
            if (id != bolum.BolumNo)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    dbcontext.Update(bolum);
                    dbcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
                return View(bolum);
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

