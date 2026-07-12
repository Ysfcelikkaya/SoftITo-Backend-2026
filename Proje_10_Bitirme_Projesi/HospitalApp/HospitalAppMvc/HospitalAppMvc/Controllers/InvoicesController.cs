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
    public class InvoicesController : Controller
    {
        private readonly HttpClient _httpClient;

        public InvoicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // ================= 1. FATURALAR LİSTESİ (GET) =================
        public async Task<IActionResult> Index()
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Invoices");

            var invoices = new List<InvoiceViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                invoices = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(json) ?? new List<InvoiceViewModel>();
            }

            return View(invoices);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            AttachToken();

            // 1. Randevuları Çek (SADECE "İPTAL EDİLMEYENLER" GELSİN)
            var appResponse = await _httpClient.GetAsync("https://localhost:7150/api/Appointments");
            var appList = new List<SelectListItem>();
            if (appResponse.IsSuccessStatusCode)
            {
                var apps = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(await appResponse.Content.ReadAsStringAsync());
                if (apps != null)
                {
                    // "Cancelled" (İptal) olmayanları filtrele
                    foreach (var a in apps.Where(x => x.Status != "Cancelled"))
                    {
                        appList.Add(new SelectListItem { Value = a.Id.ToString(), Text = $"[Ayakta Tedavi] {a.PatientName} - Dr. {a.DoctorName} ({a.AppointmentDate:dd.MM.yyyy})" });
                    }
                }
            }
            ViewBag.Appointments = appList;

            // 2. Yatışları Çek
            var admResponse = await _httpClient.GetAsync("https://localhost:7150/api/Admissions");
            var admList = new List<SelectListItem>();
            if (admResponse.IsSuccessStatusCode)
            {
                var adms = JsonConvert.DeserializeObject<List<AdmissionViewModel>>(await admResponse.Content.ReadAsStringAsync());
                if (adms != null)
                {
                    foreach (var ad in adms)
                    {
                        admList.Add(new SelectListItem { Value = ad.Id.ToString(), Text = $"[Yatarak Tedavi] {ad.PatientName} - Oda: {ad.RoomNumber}" });
                    }
                }
            }
            ViewBag.Admissions = admList;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            if (model.AppointmentId == null && model.AdmissionId == null)
            {
                TempData["Error"] = "Lütfen bir Randevu VEYA bir Yatış seçin!";
                return RedirectToAction("Create");
            }

            AttachToken();
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7150/api/Invoices", content);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index");

            TempData["Error"] = "Fatura oluşturulamadı.";
            return RedirectToAction("Index");
        }

        // ================= 4. FATURAYI ÖDE (POST) =================
        [HttpPost]
        public async Task<IActionResult> Pay(int id)
        {
            AttachToken();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"https://localhost:7150/api/Invoices/pay/{id}", content);

            return RedirectToAction("Index");
        }
        // ================= YAZDIR / PDF İNDİR (GET) =================
        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            AttachToken();
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Invoices");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var invoices = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(json);
                var invoice = invoices?.FirstOrDefault(i => i.Id == id);
                if (invoice != null)
                {
                    return View(invoice); // Print.cshtml'e yolla
                }
            }
            return RedirectToAction("Index");
        }
    }
}