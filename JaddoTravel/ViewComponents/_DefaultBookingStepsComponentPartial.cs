using JadooTravel.Services.RezervationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingStepsComponentPartial:ViewComponent
    {
        private readonly IRezervationService _rezervationService;

        public _DefaultBookingStepsComponentPartial(IRezervationService rezervationService)
        {
            _rezervationService = rezervationService;
        }

        public IViewComponentResult Invoke()
        {
            var value= _rezervationService.GetAllRezervationAsync();
            return View(value);
        }
    }
}
