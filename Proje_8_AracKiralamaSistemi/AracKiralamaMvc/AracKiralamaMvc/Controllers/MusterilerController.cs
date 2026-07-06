using AracKiralamaMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AracKiralamaMvc.Controllers
{
    public class MusterilerController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7051/api/Musteriler/GetMusteriler").Result;
            List<Musteri> musteriler = new List<Musteri>();
            if (response.IsSuccessStatusCode)
                musteriler = JsonConvert.DeserializeObject<List<Musteri>>(response.Content.ReadAsStringAsync().Result);
            return View(musteriler);
        }

        [HttpGet]
        public IActionResult Create() => View(new Musteri());

        [HttpPost]
        public IActionResult Create(Musteri musteri)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(musteri), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7051/api/Musteriler/AddMusteri", content).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7051/api/Musteriler/GetMusteriById/{id}").Result;
            var musteri = new Musteri();
            if (response.IsSuccessStatusCode)
                musteri = JsonConvert.DeserializeObject<Musteri>(response.Content.ReadAsStringAsync().Result);
            return View(musteri);
        }

        [HttpPost]
        public IActionResult Edit(Musteri musteri)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(musteri), System.Text.Encoding.UTF8, "application/json");
            var response = client.PutAsync("https://localhost:7051/api/Musteriler/UpdateMusteri", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7051/api/Musteriler/DeleteMusteri/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}