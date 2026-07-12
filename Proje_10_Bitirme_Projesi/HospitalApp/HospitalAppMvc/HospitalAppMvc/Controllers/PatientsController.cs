using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace HospitalAppMvc.Controllers
{
    [Authorize(Roles = "Admin, Doktor, Doctor")]
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;

        public PatientsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7241/");
        }

        private void AttachToken()
        {
            string token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<PatientViewModel> patients = new List<PatientViewModel>();
            string apiUrl = string.IsNullOrEmpty(searchString) ? "api/PatientsRead" : $"api/PatientsRead/SearchPatientByName?name={searchString}";

            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<PatientViewModel>>(jsonString);
            }
            return View(patients);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AttachToken();
            // Açılır kutu için Kullanıcıları (Users) Çek
            var response = await _httpClient.GetAsync("https://localhost:7150/api/Users");
            var usersList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
                if (users != null)
                {
                    // Sadece Hasta rolünde olanları (RoleId = 2) listele
                    foreach (var u in users.Where(x => x.RoleId == 2))
                    {
                        usersList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = u.Id.ToString(), Text = $"{u.Username} ({u.Email})" });
                    }
                }
            }
            ViewBag.Users = usersList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                AttachToken();
                var response = await _httpClient.PostAsync("https://localhost:7150/api/Patients", content);
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                // Eğer form hata verirse (Örn: aynı TC), Combobox kaybolmasın diye listeyi tekrar dolduruyoruz
                var userResponse = await _httpClient.GetAsync("https://localhost:7150/api/Users");
                var usersList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
                if (userResponse.IsSuccessStatusCode)
                {
                    var json = await userResponse.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
                    if (users != null)
                    {
                        foreach (var u in users.Where(x => x.RoleId == 2))
                        {
                            usersList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = u.Id.ToString(), Text = $"{u.Username} ({u.Email})" });
                        }
                    }
                }
                ViewBag.Users = usersList;

                ViewBag.Error = $"API Hatası ({response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AttachToken();
            var response = await _httpClient.GetAsync($"https://localhost:7150/api/Patients/{id}");
            if (response.IsSuccessStatusCode)
            {
                // Edit ekranında da Hastayı farklı bir hesaba bağlamak isteyebiliriz diye listeyi çekiyoruz
                var usersResp = await _httpClient.GetAsync("https://localhost:7150/api/Users");
                var usersList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
                if (usersResp.IsSuccessStatusCode)
                {
                    var usersJson = await usersResp.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UserViewModel>>(usersJson);
                    if (users != null)
                    {
                        foreach (var u in users.Where(x => x.RoleId == 2))
                        {
                            usersList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = u.Id.ToString(), Text = $"{u.Username} ({u.Email})" });
                        }
                    }
                }
                ViewBag.Users = usersList;

                var jsonString = await response.Content.ReadAsStringAsync();
                var patient = JsonConvert.DeserializeObject<PatientViewModel>(jsonString);
                return View(patient);
            }
            return Content($"Edit Getirme Hatası ({response.StatusCode}): Lütfen bu hatayı kontrol edin.");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                AttachToken();
                var response = await _httpClient.PutAsync($"https://localhost:7150/api/Patients/{model.Id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                // Hata durumunda dropdown'u tekrar doldur ki sayfa çökmesin
                var userResponse = await _httpClient.GetAsync("https://localhost:7150/api/Users");
                var usersList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
                if (userResponse.IsSuccessStatusCode)
                {
                    var json = await userResponse.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
                    if (users != null)
                    {
                        foreach (var u in users.Where(x => x.RoleId == 2))
                        {
                            usersList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = u.Id.ToString(), Text = $"{u.Username} ({u.Email})" });
                        }
                    }
                }
                ViewBag.Users = usersList;

                ViewBag.Error = $"API Hatası ({response.StatusCode}): {await response.Content.ReadAsStringAsync()}";
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            AttachToken();
            var response = await _httpClient.DeleteAsync($"https://localhost:7150/api/Patients/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Hasta ve geçmiş kayıtları sistemden tamamen silindi.";
            }
            else
            {
                TempData["Error"] = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction("Index");
        }
    }
}