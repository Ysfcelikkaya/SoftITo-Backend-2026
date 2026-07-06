using AracKiralamaMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AracKiralamaMvc.Controllers
{
    public class AraclarController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7051/api/Araclar/GetAraclar").Result;

            List<Arac> araclar = new List<Arac>();
            if (response.IsSuccessStatusCode)
            {
                araclar = JsonConvert.DeserializeObject<List<Arac>>(response.Content.ReadAsStringAsync().Result);
            }

            return View(araclar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Arac());
        }

        [HttpPost]
        public IActionResult Create(Arac arac)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(arac),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync("https://localhost:7051/api/Araclar/AddArac", content).Result;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7051/api/Araclar/GetAracById/{id}").Result;

            var arac = new Arac();
            if (response.IsSuccessStatusCode)
            {
                arac = JsonConvert.DeserializeObject<Arac>(response.Content.ReadAsStringAsync().Result);
            }

            return View(arac);
        }

        [HttpPost]
        public IActionResult Edit(Arac arac)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(arac),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = client.PutAsync("https://localhost:7051/api/Araclar/UpdateArac", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7051/api/Araclar/DeleteArac/{id}").Result;

            return RedirectToAction("Index");
        }
    }
}