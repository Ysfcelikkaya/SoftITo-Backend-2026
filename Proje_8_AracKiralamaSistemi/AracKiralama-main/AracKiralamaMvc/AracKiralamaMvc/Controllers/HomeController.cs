using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AracKiralamaMvc.Models;
using Microsoft.AspNetCore.Authorization;
namespace AracKiralamaMvc.Controllers

{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var aracResponse = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;
            int toplamArac = 0;
            if (aracResponse.IsSuccessStatusCode)
            {
                var araclar = JsonConvert.DeserializeObject<List<Arac>>(aracResponse.Content.ReadAsStringAsync().Result);
                toplamArac = araclar?.Count ?? 0;
            }

            var musteriResponse = client.GetAsync("https://localhost:7051/api/Musteriler/GetMusteriler").Result;
            int toplamMusteri = 0;
            if (musteriResponse.IsSuccessStatusCode)
            {
                var musteriler = JsonConvert.DeserializeObject<List<Musteri>>(musteriResponse.Content.ReadAsStringAsync().Result);
                toplamMusteri = musteriler?.Count ?? 0;
            }

            var odemeResponse = client.GetAsync("https://localhost:7051/api/Odemeler/GetOdemeler").Result;
            decimal toplamGelir = 0;
            if (odemeResponse.IsSuccessStatusCode)
            {
                var odemeler = JsonConvert.DeserializeObject<List<Odeme>>(odemeResponse.Content.ReadAsStringAsync().Result);
                toplamGelir = odemeler?.Sum(o => o.Tutar) ?? 0;
            }

            var kiralamaResponse = client.GetAsync("https://localhost:7051/api/Kiralamalar/GetKiralamalar").Result;
            int aktifKiralamalar = 0;
            List<Kiralama> sonKiralamalar = new List<Kiralama>();

            if (kiralamaResponse.IsSuccessStatusCode)
            {
                var tumKiralamalar = JsonConvert.DeserializeObject<List<Kiralama>>(kiralamaResponse.Content.ReadAsStringAsync().Result);
                if (tumKiralamalar != null)
                {
                    aktifKiralamalar = tumKiralamalar.Count(k => k.BitisTarih.Date >= DateTime.Now.Date);
                    sonKiralamalar = tumKiralamalar.OrderByDescending(k => k.Id).Take(4).ToList();
                }
            }

            ViewBag.ToplamArac = toplamArac;
            ViewBag.ToplamMusteri = toplamMusteri;
            ViewBag.AktifKiralamalar = aktifKiralamalar;
            ViewBag.ToplamGelir = toplamGelir;

            return View(sonKiralamalar);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}