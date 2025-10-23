using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Services.FeatureService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> FeatureList()
        {
            var value=await _featureService.GetAllFeatureasync();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("FeatureList");
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureList");

        }

        [HttpGet]
        public async Task<IActionResult>UpdateFeature(string id)
        {
            var value=await _featureService.GetFeatureByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("FeatureList");
        }

    }
}
