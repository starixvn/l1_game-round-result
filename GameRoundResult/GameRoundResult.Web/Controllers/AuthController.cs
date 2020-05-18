using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameRoundResult.Web.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GameRoundResult.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IEnumerable<AuthenticationClient> clients;

        public AuthController(IOptionsSnapshot<List<AuthenticationClient>> clientAccessor)
        {
            clients = clientAccessor.Value;
        }

        public async Task<IActionResult> Index(string key)
        {
            var client = clients.FirstOrDefault(x => x.Key == key);

            if (client != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, client.Name),
                    new Claim(CustomClaimTypes.TimeZone, client.TimeZone)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "GameRoundResult");
            }

            return BadRequest();
        }
    }
}