using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
