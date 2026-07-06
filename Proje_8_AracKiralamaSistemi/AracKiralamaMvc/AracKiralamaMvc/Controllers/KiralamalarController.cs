using AracKiralamaMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AracKiralamaMvc.Controllers
{
    public class KiralamalarController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7051/api/Kiralamalar/GetKiralamalar").Result;
            List<Kiralama> kiralamalar = new List<Kiralama>();
            if (response.IsSuccessStatusCode)
                kiralamalar = JsonConvert.DeserializeObject<List<Kiralama>>(response.Content.ReadAsStringAsync().Result);
            return View(kiralamalar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HttpClient client = new HttpClient();

            var aracResponse = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;
            if (aracResponse.IsSuccessStatusCode)
                ViewBag.Araclar = JsonConvert.DeserializeObject<List<Arac>>(aracResponse.Content.ReadAsStringAsync().Result);
            else
                ViewBag.Araclar = new List<Arac>();

            var musteriResponse = client.GetAsync("https://localhost:7051/api/Musteriler/GetMusteriler").Result;
            if (musteriResponse.IsSuccessStatusCode)
                ViewBag.Musteriler = JsonConvert.DeserializeObject<List<Musteri>>(musteriResponse.Content.ReadAsStringAsync().Result);
            else
                ViewBag.Musteriler = new List<Musteri>();

            return View(new Kiralama());
        }

        [HttpPost]
        public IActionResult Create(Kiralama model)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7051/api/Kiralamalar/AddKiralama", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var hataMesaji = response.Content.ReadAsStringAsync().Result;
                return Content("API'DEN HATA GELDİ: " + hataMesaji);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();

            var aracResponse = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;
            if (aracResponse.IsSuccessStatusCode)
                ViewBag.Araclar = JsonConvert.DeserializeObject<List<Arac>>(aracResponse.Content.ReadAsStringAsync().Result);

            var musteriResponse = client.GetAsync("https://localhost:7051/api/Musteriler/GetMusteriler").Result;
            if (musteriResponse.IsSuccessStatusCode)
                ViewBag.Musteriler = JsonConvert.DeserializeObject<List<Musteri>>(musteriResponse.Content.ReadAsStringAsync().Result);

            var response = client.GetAsync($"https://localhost:7051/api/Kiralamalar/GetKiralamaById/{id}").Result;
            var kiralama = new Kiralama();
            if (response.IsSuccessStatusCode)
                kiralama = JsonConvert.DeserializeObject<Kiralama>(response.Content.ReadAsStringAsync().Result);

            return View(kiralama);
        }

        [HttpPost]
        public IActionResult Edit(Kiralama kiralama)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(kiralama), System.Text.Encoding.UTF8, "application/json");
            var response = client.PutAsync("https://localhost:7051/api/Kiralamalar/UpdateKiralama", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7051/api/Kiralamalar/DeleteKiralama/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}