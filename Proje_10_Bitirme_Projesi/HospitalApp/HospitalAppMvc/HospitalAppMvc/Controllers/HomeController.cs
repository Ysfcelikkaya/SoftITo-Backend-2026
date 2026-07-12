using HospitalAppMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalAppMvc.Controllers
{
    [Authorize] // DİKKAT: Giriş yapmayanları (Token'ı olmayanları) direkt Login sayfasına kovar!
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

            // Dapper API'mizin Adresi (Kendi portunuza göre güncelleyin)
            _httpClient.BaseAddress = new Uri("https://localhost:7241/");
        }

        public async Task<IActionResult> Index()
        {
            // Dapper API'deki o yazdığımız "Çoklu Sorgu (QueryMultiple)" metodunu çağırıyoruz
            var response = await _httpClient.GetAsync("api/Dashboard/GetHospitalStatistics");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<DashboardViewModel>(jsonString);

                // Gelen verileri HTML sayfasına (View) yolluyoruz
                return View(model);
            }

            // API kapalıysa veya hata varsa boş sayfa göster
            return View(new DashboardViewModel());
        }
    }
}