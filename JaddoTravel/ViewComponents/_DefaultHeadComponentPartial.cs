using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
