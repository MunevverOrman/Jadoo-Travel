using JadooTravel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class AIController : Controller
    {
        private readonly OpenAiTravelService _openAiTravelService;

        public AIController(OpenAiTravelService openAiTravelService)
        {
            _openAiTravelService = openAiTravelService;
        }

        [HttpPost]
        public async Task<IActionResult> CityGuideAjax([FromBody] CityRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.City))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Lütfen bir şehir giriniz."
                });
            }

            // 1) Şu anki UI culture’dan dil kodunu al (tr, en, fr)
            var culture = CultureInfo.CurrentUICulture;
            var languageCode = culture.TwoLetterISOLanguageName; // "tr", "en", "fr"

            // 2) Servise şehir + dil kodu gönder
            var result = await _openAiTravelService.GetPlacesForCityAsync(request.City, languageCode);

            return Json(new
            {
                success = true,
                city = request.City,
                result = result
            });
        }
    }

    public class CityRequest
    {
        public string City { get; set; }
    }
}
