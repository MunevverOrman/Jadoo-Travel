using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class LanguageController : Controller
    {
      
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(culture))
                culture = "tr-TR";

            if (string.IsNullOrWhiteSpace(returnUrl))
                returnUrl = "/";

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            return LocalRedirect(returnUrl);
        }
    }
}
