using HrProjectMvc.Data;
using HrProjectMvc.Filters;
using HrProjectMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HrProjectMvc.Controllers
{
    [LoginCheck]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.UserCount = _context.Users.Count();
            ViewBag.RoleCount = _context.Roles.Count();
            ViewBag.TotalRelations = _context.Users.Count();
            HttpClient client = new HttpClient();


            var developers = JsonConvert.DeserializeObject<List<Developers>>(
                client.GetStringAsync("https://localhost:7202/api/Developers/GetDevelopers").Result
            );

            var tasks = JsonConvert.DeserializeObject<List<Tasks>>(
                client.GetStringAsync("https://localhost:7202/api/Tasks/GetTasks").Result
            );

            var projects = JsonConvert.DeserializeObject<List<Projects>>(
                client.GetStringAsync("https://localhost:7202/api/Projects/GetProjects").Result
            );

            ViewBag.DeveloperCount = developers.Count;
            ViewBag.TaskCount = tasks.Count;
            ViewBag.ProjectCount = projects.Count;

            return View();
        }
    }
}