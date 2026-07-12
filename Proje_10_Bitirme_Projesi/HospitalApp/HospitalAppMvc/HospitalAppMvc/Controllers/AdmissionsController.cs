using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    [Authorize] // Güvenlik kilidi
    public class AdmissionsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdmissionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // ================= 1. YATIŞ LİSTESİ (GET) =================
        public async Task<IActionResult> Index()
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Admissions");

            var admissions = new List<AdmissionViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                admissions = JsonConvert.DeserializeObject<List<AdmissionViewModel>>(json) ?? new List<AdmissionViewModel>();
            }

            return View(admissions);
        }

        // ================= 2. YENİ YATIŞ EKRANI (GET) =================
        [HttpGet]
        [Authorize(Roles = "Admin, Doktor")] // Sadece Doktor ve Admin yatış verebilir!
        public async Task<IActionResult> Create()
        {
            AttachToken();

            // 1. TÜM HASTALARI ÇEK
            var patResponse = await _httpClient.GetAsync("https://localhost:7150/api/Patients");
            if (patResponse.IsSuccessStatusCode)
            {
                var json = await patResponse.Content.ReadAsStringAsync();
                var pats = JsonConvert.DeserializeObject<List<dynamic>>(json);
                var patList = new List<SelectListItem>();
                if (pats != null)
                {
                    foreach (var p in pats)
                        patList.Add(new SelectListItem { Value = p.id.ToString(), Text = $"{p.firstName} {p.lastName}" });
                }
                ViewBag.Patients = patList;
            }

            // 2. SADECE BOŞ ODALARI ÇEK (FİLTRELEME)
            var roomResponse = await _httpClient.GetAsync("https://localhost:7150/api/Rooms");
            if (roomResponse.IsSuccessStatusCode)
            {
                var json = await roomResponse.Content.ReadAsStringAsync();
                var allRooms = JsonConvert.DeserializeObject<List<dynamic>>(json);
                var emptyRoomsList = new List<SelectListItem>();

                if (allRooms != null)
                {
                    foreach (var r in allRooms)
                    {
                        // EĞER ODA BOŞSA (isOccupied == false) LİSTEYE EKLE!
                        if (r.isOccupied == false)
                        {
                            emptyRoomsList.Add(new SelectListItem { Value = r.id.ToString(), Text = $"Oda {r.roomNumber} - {r.type}" });
                        }
                    }
                }
                ViewBag.EmptyRooms = emptyRoomsList;
            }

            return View();
        }

        // ================= 3. YATIŞI KAYDET (POST) =================
        [HttpPost]
        [Authorize(Roles = "Admin, Doktor")]
        public async Task<IActionResult> Create(AdmissionViewModel model)
        {
            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7150/api/Admissions", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index");

            ViewBag.Error = "Yatış gerçekleştirilemedi.";
            return RedirectToAction("Index"); // Basitlik adına hata olsa da listeye atsın
        }

        // ================= 4. HASTAYI TABURCU ET (POST) =================
        [HttpPost]
        [Authorize(Roles = "Admin, Doktor")]
        public async Task<IActionResult> Discharge(int id)
        {
            AttachToken();
            // Veri göndermemize gerek yok, sadece id ile PUT isteği atıyoruz
            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"https://localhost:7150/api/Admissions/discharge/{id}", content);

            return RedirectToAction("Index");
        }
    }
}