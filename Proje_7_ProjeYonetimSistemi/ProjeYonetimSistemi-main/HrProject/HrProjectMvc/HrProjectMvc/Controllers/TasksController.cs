using HrProjectMvc.Filters;
using HrProjectMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace HrProjectMvc.Controllers
{
    [LoginCheck]
    public class TasksController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync("https://localhost:7202/api/Tasks/GetTasks").Result;

            List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>
                (response.Content.ReadAsStringAsync().Result);

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Tasks());
        }

        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(task),
                Encoding.UTF8,
                "application/json"
            );

            client.PostAsync(
                "https://localhost:7202/api/Tasks/AddTasks",
                content
            ).Wait();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync(
                $"https://localhost:7202/api/Tasks/GetTasks/{id}"
            ).Result;

            var task = JsonConvert.DeserializeObject<Tasks>(
                response.Content.ReadAsStringAsync().Result
            );

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Tasks task)
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(task),
                Encoding.UTF8,
                "application/json"
            );

            client.PostAsync(
                $"https://localhost:7202/api/Tasks/UpdateTasks/{task.TaskId}",
                content
            ).Wait();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();

            client.DeleteAsync(
                $"https://localhost:7202/api/Tasks/DeleteTasks/{id}"
            ).Wait();

            return RedirectToAction("Index");
        }
    }
}
