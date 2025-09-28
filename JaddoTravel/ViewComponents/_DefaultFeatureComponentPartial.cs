using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
