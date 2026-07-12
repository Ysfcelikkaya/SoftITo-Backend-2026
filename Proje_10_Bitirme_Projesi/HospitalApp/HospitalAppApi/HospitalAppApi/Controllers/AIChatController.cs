using HospitalAppApi.Models;
using HospitalAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIChatController : ControllerBase
    {
        private readonly SymptomCheckerService _aiService;

        public AIChatController(SymptomCheckerService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("Analyze")]
        public IActionResult Analyze([FromBody] ChatRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                return BadRequest("Lütfen bir şikayet belirtin.");

            // Kendi yerel sistemimizden anında cevap alıyoruz
            var result = _aiService.AnalyzeSymptom(request.Message);
            return Ok(result);
        }
    }
}