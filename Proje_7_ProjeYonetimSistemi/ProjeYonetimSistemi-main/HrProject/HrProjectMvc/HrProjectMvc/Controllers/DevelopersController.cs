using HrProjectMvc.Filters;
using HrProjectMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HrProjectMvc.Controllers
{
    [LoginCheck]
    public class DevelopersController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync("https://localhost:7202/api/Developers/GetDevelopers").Result;

            List<Developers> developers = JsonConvert.DeserializeObject<List<Developers>>
                (response.Content.ReadAsStringAsync().Result);

            return View(developers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Developers());
        }

        [HttpPost]
        public IActionResult Create(Developers developers)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(developers),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync(
                "https://localhost:7202/api/Developers/AddDevelopers",
                content
            ).Result;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync(
                $"https://localhost:7202/api/Developers/GetDevelopersById/{id}"
            ).Result;

            var developer = JsonConvert.DeserializeObject<Developers>(
                response.Content.ReadAsStringAsync().Result
            );

            return View(developer);
        }

        [HttpPost]
        public IActionResult Edit(Developers developers)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(developers),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PutAsync(
                "https://localhost:7202/api/Developers/UpdateDevelopers",
                content
            ).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();

            var response = client.DeleteAsync(
                $"https://localhost:7202/api/Developers/DeleteDevelopers/{id}"
            ).Result;

            return RedirectToAction("Index");
        }
    }
}