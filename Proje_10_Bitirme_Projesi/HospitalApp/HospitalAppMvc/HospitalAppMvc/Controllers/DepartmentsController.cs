using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    [Authorize(Roles = "Admin")] // KİLİT: Bu Yönetim Sayfasına SADECE ADMİN Girebilir!
    public class DepartmentsController : Controller
    {
        private readonly HttpClient _httpClient;

        public DepartmentsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // ================= 1. LİSTELEME =================
        public async Task<IActionResult> Index()
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Departments");
            List<DepartmentViewModel> depts = new List<DepartmentViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                depts = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(json);
            }
            return View(depts);
        }


        // ================= 2. EKLEME SAYFASINI AÇ =================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ================= 3. EKLENEN VERİYİ KAYDET =================
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                AttachToken();
                var response = await _httpClient.PostAsync("https://localhost:7150/api/Departments", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                ViewBag.Error = $"Ekleme başarısız: {await response.Content.ReadAsStringAsync()}";
            }
            return View(model);
        }
        // ================= DÜZENLEME (EDIT) EKRANINI AÇ =================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AttachToken();
            var response = await _httpClient.GetAsync($"https://localhost:7150/api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dept = JsonConvert.DeserializeObject<DepartmentViewModel>(json);
                return View(dept);
            }
            return RedirectToAction("Index");
        }

        // ================= DÜZENLEME (EDIT) KAYDET =================
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                AttachToken();
                // API'ye Put isteği atıyoruz
                var response = await _httpClient.PutAsync($"https://localhost:7150/api/Departments/{model.Id}", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                ViewBag.Error = $"Güncelleme Hatası: {await response.Content.ReadAsStringAsync()}";
            }
            return View(model);
        }

        // ================= 4. SİLME İŞLEMİ =================
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            AttachToken();
            await _httpClient.DeleteAsync($"https://localhost:7150/api/Departments/{id}");
            return RedirectToAction("Index");
        }
    }
}