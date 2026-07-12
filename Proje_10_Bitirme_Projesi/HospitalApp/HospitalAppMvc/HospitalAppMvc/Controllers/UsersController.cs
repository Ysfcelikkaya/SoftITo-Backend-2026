using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    [Authorize(Roles = "Admin, Yönetici")]
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        public UsersController(IHttpClientFactory httpClientFactory) { _httpClient = httpClientFactory.CreateClient(); }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // --- LISTELEME (READ) ---
        public async Task<IActionResult> Index()
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Users");
            List<UserViewModel> users = new List<UserViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(json) ?? new List<UserViewModel>();
            }
            return View(users);
        }

        // --- YENİ KULLANICI EKLEME (CREATE) ---
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7150/api/Users", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }

        // --- DÜZENLEME (UPDATE) ---
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AttachToken();
            // Tüm kullanıcıları çekip ID'ye göre buluyoruz
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Users");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
                var user = users?.FirstOrDefault(u => u.Id == id);
                if (user != null) return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7150/api/Users/{model.Id}", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }

        // --- SİLME / İMHA (DELETE) ---
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            AttachToken();
            var response = await _httpClient.DeleteAsync($"https://localhost:7150/api/Users/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kullanıcı kökünden silindi!";
            }
            else
            {
                TempData["Error"] = await response.Content.ReadAsStringAsync();
            }

            return RedirectToAction("Index");
        }
    }
}