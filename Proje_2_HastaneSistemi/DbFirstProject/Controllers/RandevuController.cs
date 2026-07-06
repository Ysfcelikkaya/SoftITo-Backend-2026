using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirstProject.Models;
namespace DbFirstProject.Controllers
{
    public class RandevuController : Controller
    {
        public readonly AppDbContext dbcontext;
        public RandevuController(AppDbContext dbcontext)
        { this.dbcontext = dbcontext; }
        public IActionResult Index()
        {
            var result = dbcontext.Randevus.Include(r => r.Hasta).Include(r => r.Doktor).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var doktorlar = dbcontext.Doktors.Select(d => new { Id = d.Id, AdSoyad = d.Ad + " " + d.Soyad }).ToList();
            var hastalar = dbcontext.Hastas.Select(h => new { Id = h.Id, AdSoyad = h.Ad + " " + h.Soyad }).ToList();
            ViewBag.DoktorId = new SelectList(doktorlar, "Id", "AdSoyad");
            ViewBag.HastaId = new SelectList(hastalar, "Id", "AdSoyad");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Randevu randevu)
        {
            ModelState.Remove("Hasta");
            ModelState.Remove("Doktor");
            if (ModelState.IsValid)
            {
                dbcontext.Randevus.Add(randevu);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            var doktorlar = dbcontext.Doktors.Select(d => new { Id = d.Id, AdSoyad = d.Ad + " " + d.Soyad }).ToList();
            var hastalar = dbcontext.Hastas.Select(h => new { Id = h.Id, AdSoyad = h.Ad + " " + h.Soyad }).ToList();
            ViewBag.DoktorId = new SelectList(doktorlar, "Id", "AdSoyad");
            ViewBag.HastaId = new SelectList(hastalar, "Id", "AdSoyad");
            return View(randevu);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Güncellenecek randevuyu buluyoruz
            var result = dbcontext.Randevus.Find(id);
            if (result == null)
            {
                return NotFound(); // Randevu bulunamazsa hata dön
            }

            // ComboBox'ların (Dropdown) içinde doktor ve hastaların listelenmesi için verileri çekiyoruz
            var doktorlar = dbcontext.Doktors.Select(d => new { Id = d.Id, AdSoyad = d.Ad + " " + d.Soyad }).ToList();
            var hastalar = dbcontext.Hastas.Select(h => new { Id = h.Id, AdSoyad = h.Ad + " " + h.Soyad }).ToList();

            // Eski seçilen hasta ve doktorun select listesinde otomatik seçili gelmesini sağlıyoruz
            ViewBag.DoktorId = new SelectList(doktorlar, "Id", "AdSoyad", result.DoktorId);
            ViewBag.HastaId = new SelectList(hastalar, "Id", "AdSoyad", result.HastaId);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound(); // Güvenlik kontrolü
            }

            // İlk başta yaşadığımız ilişkili tablo doğrulama engelini burada da kaldırıyoruz
            ModelState.Remove("Hasta");
            ModelState.Remove("Doktor");

            if (ModelState.IsValid)
            {
                dbcontext.Update(randevu);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bir hata oluşursa ve sayfa yenilenirse ComboBox'lar patlamasın diye tekrar dolduruyoruz
            var doktorlar = dbcontext.Doktors.Select(d => new { Id = d.Id, AdSoyad = d.Ad + " " + d.Soyad }).ToList();
            var hastalar = dbcontext.Hastas.Select(h => new { Id = h.Id, AdSoyad = h.Ad + " " + h.Soyad }).ToList();
            ViewBag.DoktorId = new SelectList(doktorlar, "Id", "AdSoyad", randevu.DoktorId);
            ViewBag.HastaId = new SelectList(hastalar, "Id", "AdSoyad", randevu.HastaId);

            return View(randevu);
        }
       
        public IActionResult Delete(int id)
        {
            var result = dbcontext.Randevus.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Randevu randevu)
        {
            dbcontext.Remove(randevu);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rapor(string siralama, string aramaKelimeleri)
        {
            var randevular = dbcontext.Randevus.Include(r => r.Hasta).Include(r => r.Doktor).AsQueryable();

            if (!string.IsNullOrEmpty(aramaKelimeleri))
            {
                randevular = randevular.Where(r => r.Hasta.Ad.Contains(aramaKelimeleri) ||
                                                   r.Hasta.Soyad.Contains(aramaKelimeleri) ||
                                                   r.Doktor.Ad.Contains(aramaKelimeleri) ||
                                                   r.Doktor.Soyad.Contains(aramaKelimeleri));
            }

            switch (siralama)
            {
                case "tarih_desc":
                    randevular = randevular.OrderByDescending(r => r.RandevuTarihi);
                    break;
                case "tarih_asc":
                    randevular = randevular.OrderBy(r => r.RandevuTarihi);
                    break;
                case "hasta_asc":
                    randevular = randevular.OrderBy(r => r.Hasta.Ad);
                    break;
                case "hasta_desc":
                    randevular = randevular.OrderByDescending(r => r.Hasta.Ad);
                    break;
                case "doktor_asc":
                    randevular = randevular.OrderBy(r => r.Doktor.Ad);
                    break;
                case "doktor_desc":
                    randevular = randevular.OrderByDescending(r => r.Doktor.Ad);
                    break;
                default:
                    randevular = randevular.OrderByDescending(r => r.RandevuTarihi);
                    break;
            }

            ViewBag.SeciliSira = siralama;
            ViewBag.GecerliArama = aramaKelimeleri;

            return View(randevular.ToList());
        }
    }
}
