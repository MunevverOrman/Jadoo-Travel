using JadooTravel.Models;
using JadooTravel.Services.IDestinationService;
using JadooTravel.Services.RezervationServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;      
using System.Threading.Tasks;   

namespace JadooTravel.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IRezervationService _rezervationService;

        public StatisticsController(IDestinationService destinationService, IRezervationService rezervationService)
        {
            _destinationService = destinationService;
            _rezervationService = rezervationService;
        }

        public async Task<IActionResult> Index()
        {
            var allDestinations = await _destinationService.GetAllDestinationAsync();

      
            var ordered = allDestinations
                .OrderByDescending(x => x.DestinationId)
                .ToList();

            var vm = new StatisticsViewModel
            {
                LastDestinations = ordered.Take(5).ToList(),          
                LastDestinationsForCards = ordered.Take(4).ToList()  
            };

            return View(vm);
        }


        public async Task<IActionResult> GetDestinationChart()
        {
            var destinations = await _destinationService.GetAllDestinationAsync();
            var values = destinations.Select(x => new
            {
                label = x.CityCountry,   
                capacity = x.Capacity,   
                price = x.Price         
            }).ToList();

            return Json(values);
        }

      
        public async Task<IActionResult> GetTopDestinationsChart()
        {
            var destinations = await _destinationService.GetAllDestinationAsync();

            var data = destinations
                .OrderByDescending(x => x.Price)   
                .Take(5)                           
                .Select(x => new
                {
                    label = x.CityCountry,        
                    value = x.Price                 
                })
                .ToList();

            return Json(data);
        }

        public async Task<IActionResult> GetTopCapacityDestinationsChart()
        {
            var destinations = await _destinationService.GetAllDestinationAsync();

            var data = destinations
                .OrderByDescending(x => x.Capacity) 
                .Take(5)
                .Select(x => new
                {
                    label = x.CityCountry,
                    value = x.Capacity
                })
                .ToList();

            return Json(data);
        }


    }
}