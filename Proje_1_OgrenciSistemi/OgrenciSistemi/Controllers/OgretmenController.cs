using Microsoft.AspNetCore.Mvc;
using OgrenciSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace OgrenciSistemi.Controllers
{
    public class OgretmenController : Controller
    {
        public readonly ApplicationDbContext dbcontext;

        public OgretmenController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        // 1. LİSTELEME
        public IActionResult Index()
        {
            var result = dbcontext.Ogretmens.ToList();
            return View(result);
        }

        // 2. EKLEME SAYFASI (Form İlk Açılış)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Bolumler = dbcontext.Bolums.ToList();
            return View();
        }

        // 3. EKLEME İŞLEMİ (Kaydet Butonuna Basıldığında)
        [HttpPost]
        public IActionResult Create(Ogretmen ogretmen)
        {
            // KİLİT NOKTA: Model içindeki sanal 'bolum' nesnesini kontrolden muaf tutuyoruz.
            // Bu sayede .NET arka planda formu gizlice kilitlemeyi bırakıyor.
            ModelState.Remove("bolum");

            if (!ModelState.IsValid)
            {
                ViewBag.Bolumler = dbcontext.Bolums.ToList();
                return View(ogretmen);
            }

            try
            {
                dbcontext.Ogretmens.Add(ogretmen);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                ViewBag.VeritabaniHatasi = innerException?.Message;
                ViewBag.Bolumler = dbcontext.Bolums.ToList();
                return View(ogretmen);
            }
        }

        // 4. DÜZENLEME SAYFASI
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = dbcontext.Ogretmens.Find(id);
            if (result == null) return NotFound();

            ViewBag.Bolumler = dbcontext.Bolums.ToList(); // Düzenlerken de dropdown dolsun
            return View(result);
        }

        // 5. DÜZENLEME İŞLEMİ
        [HttpPost]
        public IActionResult Edit(Ogretmen ogretmen)
        {
            ModelState.Remove("bolum");
            ModelState.Remove("Bolum");

            if (!ModelState.IsValid)
            {
                ViewBag.Bolumler = dbcontext.Bolums.ToList();
                return View(ogretmen);
            }

            try
            {
                dbcontext.Update(ogretmen);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                ViewBag.VeritabaniHatasi = innerException?.Message;
                ViewBag.Bolumler = dbcontext.Bolums.ToList();
                return View(ogretmen);
            }
        }

        // 6. SİLME SAYFASI
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Ogretmens.Find(id);
            return View(result);
        }

        // 7. SİLME İŞLEMİ
        [HttpPost]
        public IActionResult Delete(Ogretmen ogretmen)
        {
            dbcontext.Remove(ogretmen);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}