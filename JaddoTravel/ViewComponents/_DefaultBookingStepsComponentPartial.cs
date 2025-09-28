using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingStepsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
