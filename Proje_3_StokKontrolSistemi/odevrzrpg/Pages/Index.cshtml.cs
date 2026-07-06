using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace odevrzrpg.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalUsers { get; set; }

        // Tabloda göstereceğimiz ürün listesi
        public List<Urun> UrunListesi { get; set; }

        // Yukarıdaki kartlar için dinamik istatistikler
        public int ToplamUrunAdedi { get; set; }
        public int KritikStokSayisi { get; set; }

        [BindProperty]
        public Urun YeniUrun { get; set; }

        public void OnGet()
        {
            // Kullanıcı Sayısı (Eğer veritabanı boşsa çökmemesi için kontrol)
            TotalUsers = (StaticUserDatabase.Kullanicilar != null) ? StaticUserDatabase.Kullanicilar.Count : 0;

            // Ürünleri Listele ve İstatistikleri Hesapla
            UrunListesi = StaticProductDatabase.Urunler.OrderByDescending(x => x.Id).ToList();

            // Bütün ürünlerin "Miktar" değerlerini toplar
            ToplamUrunAdedi = UrunListesi.Sum(x => x.Miktar);

            // Miktarı 10 ve altında olanları sayar
            KritikStokSayisi = UrunListesi.Count(x => x.Miktar <= 10);
        }

        // YENİ ÜRÜN EKLEME METODU
        public IActionResult OnPostEkle()
        {
            if (YeniUrun != null && !string.IsNullOrEmpty(YeniUrun.Adi))
            {
                // Rastgele ID oluştur ve listeye ekle
                YeniUrun.Id = System.Guid.NewGuid().ToString().Substring(0, 8);
                StaticProductDatabase.Urunler.Add(YeniUrun);
            }
            return RedirectToPage();
        }

        // ÜRÜN SİLME METODU
        public IActionResult OnPostSil(string id)
        {
            var urun = StaticProductDatabase.Urunler.FirstOrDefault(x => x.Id == id);
            if (urun != null)
            {
                StaticProductDatabase.Urunler.Remove(urun);
            }
            return RedirectToPage();
        }
    }

    // --- DİNAMİK ÜRÜN VERİTABANI VE MODELİ ---
    public static class StaticProductDatabase
    {
        // Başlangıçta 3 tane hazır ürünle gelsin
        public static List<Urun> Urunler = new List<Urun>()
        {
            new Urun { Id = "PRD-001", Kodu = "LTP-1", Adi = "Lenovo ThinkPad X1", Kategori = "Elektronik", Miktar = 25 },
            new Urun { Id = "PRD-002", Kodu = "MS-2", Adi = "Logitech Kablosuz Mouse", Kategori = "Aksesuar", Miktar = 5 },
            new Urun { Id = "PRD-003", Kodu = "YZC-3", Adi = "HP Lazer Yazıcı", Kategori = "Elektronik", Miktar = 0 }
        };
    }

    public class Urun
    {
        public string Id { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Kategori { get; set; }
        public int Miktar { get; set; }
    }
}