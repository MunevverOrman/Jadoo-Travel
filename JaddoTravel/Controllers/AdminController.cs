using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
