using HrProjectMvc.Filters;
using HrProjectMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace projectbridgemvc.Controllers
{
    [LoginCheck]
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync("https://localhost:7202/api/Projects/GetProjects").Result;

            List<Projects> projects = JsonConvert.DeserializeObject<List<Projects>>
                (response.Content.ReadAsStringAsync().Result);

            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Projects());
        }

        [HttpPost]
        public IActionResult Create(Projects project)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(project),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync(
                "https://localhost:7202/api/Projects/AddProjects",
                content
            ).Result;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync(
                $"https://localhost:7202/api/Projects/GetProjects/{id}"
            ).Result;

            var project = JsonConvert.DeserializeObject<Projects>(
                response.Content.ReadAsStringAsync().Result
            );

            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Projects project)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(project),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync(
                $"https://localhost:7202/api/Projects/UpdateProjects/{project.ProjectId}",
                content
            ).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();

            var response = client.DeleteAsync(
                $"https://localhost:7202/api/Projects/DeleteProjects/{id}"
            ).Result;

            return RedirectToAction("Index");
        }
    }
}