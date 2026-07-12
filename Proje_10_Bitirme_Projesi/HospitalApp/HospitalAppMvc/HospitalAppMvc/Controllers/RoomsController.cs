using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomsController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomsController(IHttpClientFactory httpClientFactory)
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
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Rooms");

            List<RoomViewModel> rooms = new List<RoomViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                rooms = JsonConvert.DeserializeObject<List<RoomViewModel>>(json);
            }
            return View(rooms);
        }

        // ================= POLİKLİNİKLERİ GETİR =================
        private async Task PopulateDepartmentsDropdown()
        {
            var depsList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Departments");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var departments = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(json);
                if (departments != null)
                {
                    foreach (var d in departments)
                    {
                        depsList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = d.Id.ToString(), Text = d.Name });
                    }
                }
            }
            ViewBag.Departments = depsList;
        }

        // ================= 2. EKLEME SAYFASINI AÇ =================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AttachToken();
            await PopulateDepartmentsDropdown();
            return View();
        }

        // ================= 3. EKLENEN ODAYI KAYDET =================
        [HttpPost]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                AttachToken();
                var response = await _httpClient.PostAsync("https://localhost:7150/api/Rooms", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                ViewBag.Error = $"Ekleme başarısız: {await response.Content.ReadAsStringAsync()}";
            }
            AttachToken();
            await PopulateDepartmentsDropdown();
            return View(model);
        }
        // ================= DÜZENLEME (EDIT) EKRANINI AÇ =================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AttachToken();
            var response = await _httpClient.GetAsync($"https://localhost:7150/api/Rooms/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<RoomViewModel>(json);
                await PopulateDepartmentsDropdown();
                return View(room);
            }
            return RedirectToAction("Index");
        }

        // ================= DÜZENLEME (EDIT) KAYDET =================
        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                AttachToken();
                var response = await _httpClient.PutAsync($"https://localhost:7150/api/Rooms/{model.Id}", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                ViewBag.Error = $"Güncelleme Hatası: {await response.Content.ReadAsStringAsync()}";
            }
            AttachToken();
            await PopulateDepartmentsDropdown();
            return View(model);
        }

        // ================= 4. SİLME İŞLEMİ =================
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            AttachToken();
            await _httpClient.DeleteAsync($"https://localhost:7150/api/Rooms/{id}");
            return RedirectToAction("Index");
        }
    }
}