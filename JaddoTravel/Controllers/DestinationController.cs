using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Services.IDestinationService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> DestinationList()
        {
            var values = await _destinationService.GetAllDestinationAsync();
            if (values == null)
                values = new List<ResultDestinationDto>();

            return View(values); 
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto createDestinationDto)
        {
            await _destinationService.CreateDestinationAsync(createDestinationDto);
            return RedirectToAction("DestinationList");
        }
        public async Task<IActionResult> DeleteDestination(string id)
        {
            await _destinationService.DeleteDestinationAsync(id);
            return RedirectToAction("DestinationList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDestination(string id)
        {
            var values = await _destinationService.GetDestinationByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationDto updateDestinationDto)
        {
            await _destinationService.UpdateDestinationAsync(updateDestinationDto);
            return RedirectToAction("DestinationList");
        }
    }
}
