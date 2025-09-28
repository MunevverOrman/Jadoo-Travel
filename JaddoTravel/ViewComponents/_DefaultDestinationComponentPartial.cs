using JadooTravel.Services.IDestinationService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultDestinationComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _DefaultDestinationComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _destinationService.GetAllDestinationAsync();
            return View(values);
        }
    }
}
