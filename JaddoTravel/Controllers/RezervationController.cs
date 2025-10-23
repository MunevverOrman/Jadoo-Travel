using JadooTravel.Dtos.RezervationDtos;
using JadooTravel.Services.RezervationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class RezervationController : Controller
    {
        private readonly IRezervationService _rezervationService;

        public RezervationController(IRezervationService rezervationService)
        {
            _rezervationService = rezervationService;
        }

        public async Task<IActionResult> RezervationList()
        {
            var value = await _rezervationService.GetAllRezervationAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateRezervation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRezervation(CreateRezervationDto createRezervationDto)
        {
            await _rezervationService.CreateRezervationAsync(createRezervationDto);
            return RedirectToAction("RezervationList");
        }

        public async Task<IActionResult> DeleteRezervation(string id)
        {
            await _rezervationService.DeleteRezervationAsync(id);
            return RedirectToAction("RezervationList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRezervation(string id)
        {
            var values = await _rezervationService.GetRezervationByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRezervation(UpdateRezervationDto updateRezervationDto)
        {
            await _rezervationService.UpdateRezervationAsync(updateRezervationDto);
            return RedirectToAction("RezervationList");
        }
    }
    
}
