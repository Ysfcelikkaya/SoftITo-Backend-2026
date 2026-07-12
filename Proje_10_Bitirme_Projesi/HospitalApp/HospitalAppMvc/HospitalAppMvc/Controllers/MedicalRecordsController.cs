using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalAppMvc.Controllers
{
    [Authorize]
    public class MedicalRecordsController : Controller
    {
        private readonly HttpClient _httpClient;

        public MedicalRecordsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IActionResult> Index()
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/MedicalRecords");

            var records = new List<MedicalRecordViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                records = JsonConvert.DeserializeObject<List<MedicalRecordViewModel>>(json) ?? new List<MedicalRecordViewModel>();
            }

            return View(records);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doktor, Doctor")]
        public async Task<IActionResult> Create()
        {
            AttachToken();
            var appResponse = await _httpClient.GetAsync("https://localhost:7150/api/Appointments");
            if (appResponse.IsSuccessStatusCode)
            {
                var json = await appResponse.Content.ReadAsStringAsync();
                var apps = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(json);
                var appList = new List<SelectListItem>();
                if (apps != null)
                {
                    foreach (var a in apps)
                    {
                        appList.Add(new SelectListItem { Value = a.Id.ToString(), Text = $"{a.PatientName} - Dr. {a.DoctorName} ({a.AppointmentDate:dd.MM.yyyy})" });
                    }
                }
                ViewBag.Appointments = appList;
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Doktor, Doctor")]
        public async Task<IActionResult> Create(MedicalRecordViewModel model)
        {
            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7150/api/MedicalRecords", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        // ================= PRINT (PDF İNDİRME) EKRANI EKLENDİ =================
        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            AttachToken();
            // Tüm kayıtları çekip içinden tıklananı buluyoruz
            var response = await _httpClient.GetAsync("https://localhost:7150/api/MedicalRecords");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var records = JsonConvert.DeserializeObject<List<MedicalRecordViewModel>>(json);
                var record = records?.FirstOrDefault(r => r.Id == id);

                if (record != null)
                {
                    return View(record);
                }
            }
            return RedirectToAction("Index");
        }
    }
}