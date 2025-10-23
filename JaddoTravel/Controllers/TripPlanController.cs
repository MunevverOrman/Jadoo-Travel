using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class TripPlanController : Controller
    {
        private readonly ITripPlanService _tripPlanService;

        public TripPlanController(ITripPlanService tripPlanService)
        {
            _tripPlanService = tripPlanService;
        }

        public async Task<IActionResult> TripPlanList()
        {
            var value= await _tripPlanService.GetAllTripPlanAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateTripPlanList()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateTripPlan(CreateTripPlanDto createTripPlanDto)
        {
            await _tripPlanService.CreateTripPlanAsync(createTripPlanDto);
            return RedirectToAction("TripPlanList");
        }
        public async Task<IActionResult> DeleteTripPlan(string id)
        {
            await _tripPlanService.DeleteTripPlanAsync(id);
            return RedirectToAction("TripPlanList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTripPlan(string id)
        {
            var value = await _tripPlanService.GetTripPlanByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTripPlan(UpdateTripPlanDto updateTripPlanDto)
        {
            await _tripPlanService.UpdateTripPlanAsync(updateTripPlanDto);
            return RedirectToAction("TripPlanList");
        }

    }
}
