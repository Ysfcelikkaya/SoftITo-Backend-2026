using AracKiralamaMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AracKiralamaMvc.Controllers
{
    public class OdemelerController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7051/api/Odemeler/GetOdemeler").Result;
            List<Odeme> odemeler = new List<Odeme>();
            if (response.IsSuccessStatusCode)
                odemeler = JsonConvert.DeserializeObject<List<Odeme>>(response.Content.ReadAsStringAsync().Result);
            return View(odemeler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HttpClient client = new HttpClient();


            var kResponse = client.GetAsync("https://localhost:7051/api/Kiralamalar/GetKiralamalar").Result;
            if (kResponse.IsSuccessStatusCode)
                ViewBag.Kiralamalar = JsonConvert.DeserializeObject<List<Kiralama>>(kResponse.Content.ReadAsStringAsync().Result);

            var aResponse = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;
            if (aResponse.IsSuccessStatusCode)
                ViewBag.Araclar = JsonConvert.DeserializeObject<List<Arac>>(aResponse.Content.ReadAsStringAsync().Result);

            return View(new Odeme());
        }

        [HttpPost]
        public IActionResult Create(Odeme model)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7051/api/Odemeler/AddOdeme", content).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();

            var kResponse = client.GetAsync("https://localhost:7051/api/Kiralamalar/GetKiralamalar").Result;
            if (kResponse.IsSuccessStatusCode)
                ViewBag.Kiralamalar = JsonConvert.DeserializeObject<List<Kiralama>>(kResponse.Content.ReadAsStringAsync().Result);

            var aResponse = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;
            if (aResponse.IsSuccessStatusCode)
                ViewBag.Araclar = JsonConvert.DeserializeObject<List<Arac>>(aResponse.Content.ReadAsStringAsync().Result);

            var response = client.GetAsync($"https://localhost:7051/api/Odemeler/GetOdemeById/{id}").Result;
            var odeme = new Odeme();
            if (response.IsSuccessStatusCode)
                odeme = JsonConvert.DeserializeObject<Odeme>(response.Content.ReadAsStringAsync().Result);

            return View(odeme);
        }

        [HttpPost]
        public IActionResult Edit(Odeme model)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = client.PutAsync("https://localhost:7051/api/Odemeler/UpdateOdeme", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7051/api/Odemeler/DeleteOdeme/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}