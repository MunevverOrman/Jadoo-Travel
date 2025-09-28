using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
