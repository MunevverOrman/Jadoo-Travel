using JadooTravel.Services.IDestinationService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDestinationService _destinationService;

        public AdminController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDestinationCapacityChart()
        {
            var values = await _destinationService.GetAllDestinationAsync();

     
            var chartData = values.Select(x => new
            {
                cityCountry = x.CityCountry,
                capacity = x.Capacity
            });

            return Json(chartData);
        }
    }
}
