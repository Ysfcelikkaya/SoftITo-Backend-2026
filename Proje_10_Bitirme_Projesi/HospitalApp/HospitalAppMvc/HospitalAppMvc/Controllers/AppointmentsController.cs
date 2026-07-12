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
    public class AppointmentsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AppointmentsController(IHttpClientFactory httpClientFactory)
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
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Appointments");

            var apps = new List<AppointmentViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                apps = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(json) ?? new List<AppointmentViewModel>();
            }
            return View(apps);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AttachToken();
            var docsList = new List<SelectListItem>();
            var docResponse = await _httpClient.GetAsync("https://localhost:7150/api/Doctors");
            if (docResponse.IsSuccessStatusCode)
            {
                var json = await docResponse.Content.ReadAsStringAsync();
                var docs = JsonConvert.DeserializeObject<List<DoctorViewModel>>(json);
                if (docs != null)
                {
                    foreach (var d in docs)
                    {
                        docsList.Add(new SelectListItem { Value = d.Id.ToString(), Text = $"Dr. {d.FirstName} {d.LastName}" });
                    }
                }
            }
            ViewBag.Doctors = docsList;

            var patList = new List<SelectListItem>();
            var patResponse = await _httpClient.GetAsync("https://localhost:7150/api/Patients");
            if (patResponse.IsSuccessStatusCode)
            {
                var json = await patResponse.Content.ReadAsStringAsync();
                var pats = JsonConvert.DeserializeObject<List<PatientViewModel>>(json);
                if (pats != null)
                {
                    var userRole = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
                    var userIdStr = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                    if (userRole == "Patient" && !string.IsNullOrEmpty(userIdStr))
                    {
                        int uId = int.Parse(userIdStr);
                        var myPat = pats.FirstOrDefault(p => p.UserId == uId);
                        if (myPat != null) patList.Add(new SelectListItem { Value = myPat.Id.ToString(), Text = $"{myPat.FirstName} {myPat.LastName}" });
                    }
                    else
                    {
                        foreach (var p in pats) patList.Add(new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" });
                    }
                }
            }
            ViewBag.Patients = patList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7150/api/Appointments", content);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");

            ViewBag.Error = $"Randevu alınamadı: {await response.Content.ReadAsStringAsync()}";
            return View(model);
        }

        // HASTA'NIN İPTAL EDEBİLMESİ İÇİN ROLE EKLENDİ
        [HttpPost]
        [Authorize(Roles = "Admin,Doktor,Doctor,Patient")]
        public async Task<IActionResult> UpdateStatus(int id, string newStatus)
        {
            try
            {
                AttachToken();
                // string veriyi doğrudan JSON'a uygun serialize edip yolluyoruz ("Completed" -> "\"Completed\"")
                var content = new StringContent(JsonConvert.SerializeObject(newStatus), Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PutAsync($"https://localhost:7150/api/Appointments/status/{id}", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    TempData["ErrorMessage"] = $"API Hatası ({response.StatusCode}): {errorMsg}";
                }
                else
                {
                    TempData["SuccessMessage"] = "İşlem başarıyla tamamlandı.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bağlantı Hatası: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}