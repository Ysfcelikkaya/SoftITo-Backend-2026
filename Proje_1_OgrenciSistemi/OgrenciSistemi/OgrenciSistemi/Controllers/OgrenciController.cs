using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OgrenciSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace OgrenciSistemi.Controllers
{
    public class OgrenciController : Controller
    {
        public readonly ApplicationDbContext dbcontext;
        public OgrenciController(ApplicationDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        //public IActionResult Index()
        //{
        //    var result = dbcontext.Ogrencis.Include("bolum").ToList();
        //    return View(result);
        //}
        public IActionResult Index(string arama)
        {
            var result = dbcontext.Ogrencis.Include("bolum").AsQueryable();

            if (!string.IsNullOrEmpty(arama))
            {
                result = result.Where(x => x.OgrenciAdi.Contains(arama));
            }

            return View(result.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {   
            ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi");
           // ViewData["OgrenciNo"] = new SelectList(dbcontext.Ogrencis, "OgrenciNo", "OgrenciAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("OgrenciNo,OgrenciAdi,OgrenciSinif,BolumNo")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Ogrencis.Add(ogrenci);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi", ogrenci.BolumNo);
            return View(ogrenci);
        }
    }
}
