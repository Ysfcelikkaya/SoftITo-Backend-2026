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
        public IActionResult Create(Ogrenci ogrenci)
        {
            // 🎯 KRİTİK KİLİT AÇICI: .NET'in arka planda formu gizlice engellemesini durduruyoruz.
            ModelState.Remove("bolum");
            ModelState.Remove("Bolum");

            if (!ModelState.IsValid)
            {
                // Eğer formda başka bir eksik varsa sayfa çökmesin, dropdown yeniden dolsun
                ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi", ogrenci.BolumNo);
                return View(ogrenci);
            }

            try
            {
                dbcontext.Ogrencis.Add(ogrenci);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                // SQL Server'ın tam olarak hangi kolondan dolayı isyan ettiğini (InnerException) yakalayıp ekrana basıyoruz
                var innerException = ex.InnerException;
                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                ViewBag.VeritabaniHatasi = innerException?.Message;

                // Hata durumunda dropdown listenin patlamaması için yeniden dolduruyoruz
                ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi", ogrenci.BolumNo);
                return View(ogrenci);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ogrenci = dbcontext.Ogrencis.Find(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi", ogrenci.BolumNo);

            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Edit(Ogrenci ogrenci)
        {
            if (ogrenci != null)
            {
                dbcontext.Ogrencis.Update(ogrenci);
                dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BolumNo = new SelectList(dbcontext.Bolums, "BolumNo", "BolumAdi", ogrenci?.BolumNo);
            return View(ogrenci);
        }
        // ==========================================
        // 6. SİLME SAYFASI (Onay Ekranı)
        // ==========================================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Öğrenciyi bölüm bilgisiyle birlikte getiriyoruz ki ekranda hangi bölümde olduğu da görünsün
            var ogrenci = dbcontext.Ogrencis.Include("bolum").FirstOrDefault(x => x.OgrenciNo == id);

            // Eğer senin modelinde anahtar alan OgrenciNo değil de OgrenciId ise, 
            // yukarıdaki x.OgrenciNo kısmını modeline göre (örn: x.OgrenciId) düzeltmelisin.

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // ==========================================
        // 7. SİLME İŞLEMİ (Sil Butonuna Basıldığında)
        // ==========================================
        [HttpPost]
        public IActionResult Delete(Ogrenci ogrenci)
        {
            // Tıpkı öğretmenlerdeki gibi validasyon kilidine takılmasın diye sanal nesneyi muaf tutuyoruz
            ModelState.Remove("bolum");
            ModelState.Remove("Bolum");

            try
            {
                dbcontext.Ogrencis.Remove(ogrenci);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                // İlişkili kayıtlardan dolayı (örneğin bu öğrenciye bağlı notlar, dersler varsa) 
                // silme hatası alınırsa uygulamanın çökmesini engelliyoruz.
                var innerException = ex.InnerException;
                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                ViewBag.VeritabaniHatasi = "Bu öğrenci silinemez! " + innerException?.Message;

                // Hatayı ekranda göstermek için öğrenciyi sayfaya geri gönderiyoruz
                return View(ogrenci);
            }
        }
    }
}

