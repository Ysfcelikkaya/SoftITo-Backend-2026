using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HospitalAppMvc.Controllers
{
    [Authorize] // SİSTEME GİREN HERKES ULAŞABİLİR (Hasta, Doktor, Admin)
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;

        public DoctorsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // ====== KURYEYE KİMLİK (TOKEN) TAKAN OTOMATİK METOT ======
        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // ================= GET (LİSTELEME) =================
        public async Task<IActionResult> Index()
        {
            AttachToken(); // Kimliksiz listeleme yapılamaz

            // Okuma işlemini EF Core (7150) tarafına yazdığınız için kuryeyi oraya yolluyoruz!
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Doctors");

            List<DoctorViewModel> doctors = new List<DoctorViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                doctors = JsonConvert.DeserializeObject<List<DoctorViewModel>>(jsonString);
            }
            return View(doctors);
        }

        // ================= CREATE (EKLEME) EKRANINI AÇ =================
        [HttpGet]
        [Authorize(Roles = "Admin")] // SADECE ADMİN YENİ DOKTOR SAYFASINI AÇABİLİR
        public async Task<IActionResult> Create()
        {
            AttachToken(); // Kimlik kartını tak

            // API'den Kullanıcıları ve Poliklinikleri çekiyoruz (Combobox'lar için)
            var usersResponse = await _httpClient.GetAsync("https://localhost:7150/api/Users");
            var deptsResponse = await _httpClient.GetAsync("https://localhost:7150/api/Departments");

            if (usersResponse.IsSuccessStatusCode && deptsResponse.IsSuccessStatusCode)
            {
                // Gelen JSON verilerini C# listesine çevirip ViewBag ile arayüze (Ekrana) yolluyoruz
                ViewBag.Users = JsonConvert.DeserializeObject<List<UserViewModel>>(await usersResponse.Content.ReadAsStringAsync());
                ViewBag.Departments = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(await deptsResponse.Content.ReadAsStringAsync());
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

                AttachToken();
                var response = await _httpClient.PostAsync("https://localhost:7150/api/Doctors", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                var realError = await response.Content.ReadAsStringAsync();
                ViewBag.Error = $"Kayıt Hatası ({response.StatusCode}): {realError}";
            }

            // Eğer kayıt hata verirse ekrana geri dönmeden önce Combobox'ların içini tekrar doldurmalıyız ki liste kaybolmasın
            AttachToken();
            var usersResponse = await _httpClient.GetAsync("https://localhost:7150/api/Users");
            var deptsResponse = await _httpClient.GetAsync("https://localhost:7150/api/Departments");
            if (usersResponse.IsSuccessStatusCode && deptsResponse.IsSuccessStatusCode)
            {
                ViewBag.Users = JsonConvert.DeserializeObject<List<UserViewModel>>(await usersResponse.Content.ReadAsStringAsync());
                ViewBag.Departments = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(await deptsResponse.Content.ReadAsStringAsync());
            }

            return View(model);
        }

        // ================= DÜZENLEME (EDIT) EKRANINI AÇ =================
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            AttachToken();
            var response = await _httpClient.GetAsync($"https://localhost:7150/api/Doctors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonConvert.DeserializeObject<DoctorViewModel>(json);
                return View(doc);
            }
            return RedirectToAction("Index");
        }

        // ================= DÜZENLEME (EDIT) KAYDET =================
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

                AttachToken();
                var response = await _httpClient.PutAsync($"https://localhost:7150/api/Doctors/{model.Id}", content);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                ViewBag.Error = $"Güncelleme Hatası ({response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
            }
            return View(model);
        }

        // ================= DELETE (SİLME) =================
        [HttpPost]
        [Authorize(Roles = "Admin")] // KİLİT: SADECE ADMİN SİLEBİLİR!
        public async Task<IActionResult> Delete(int id)
        {
            AttachToken();
            var response = await _httpClient.DeleteAsync($"https://localhost:7150/api/Doctors/{id}");
            return RedirectToAction("Index");
        }
    }
}