using Microsoft.AspNetCore.Mvc;

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
