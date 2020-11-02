using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace GameRoundResult.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotAuthorized()
        {
            return View();
        }
    }
}
