using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.ViewFactory;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Sentry;
using TimeZoneConverter;

namespace GameRoundResult.Web.Controllers
{
    [Authorize]
    public class GameRoundResultController : Controller
    {
        private readonly IMediator mediator;
        private readonly GameTypeLocalization gameTypeLocalization;
        private readonly HostConfiguration hostConfiguration;
        private readonly IEnumerable<AuthenticationClient> clients;
        private readonly ITimeLimitedDataProtector dataProtector;
        private const string dataProtectorKey = "game-round-result-data-key";
        private const int dataProtectorLifeTimeSecond = 10;
        public const int dataCacheDuration = 15;

        public GameRoundResultController(IMediator mediator,
            GameTypeLocalization gameTypeLocalization,
            IOptionsSnapshot<List<AuthenticationClient>> clientAccessor,
            IOptionsSnapshot<HostConfiguration> hostConfigurationAccessor,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.mediator = mediator;
            this.gameTypeLocalization = gameTypeLocalization;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            clients = clientAccessor.Value;
            hostConfiguration = hostConfigurationAccessor.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GameType gameType)
        {
            var viewModel = new GameRoundResultViewModel
            {
                GameTypes = await gameTypeLocalization.GetGameListAsync(User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.SiteName)?.Value),
                GameType = gameType
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetRoundResult(GameType gameType, [FromServices] IRoundResultViewFactory viewFactory)
        {
            if (Enum.IsDefined(typeof(GameType), gameType))
            {
                return View(viewFactory.GetView(gameType));
            }

            throw new ArgumentException("Invalid game type", nameof(gameType));
        }

        [ResponseCache(Duration = dataCacheDuration, VaryByQueryKeys = new[] { "start", "length", "gameType", "roundId", "userTimeZone", "date" })]
        public async Task<IActionResult> GetData(int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date,
            [FromServices] IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            var result = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo, start, length));
            var data = result.Item2.Select(x => x.ToDataTableArray(stringLocalizer));

            return Json(new
            {
                data,
                recordsFiltered = result.Item1,
                recordsTotal = result.Item1
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetAccessUrl([FromBody] GameRoundResultAccessUrlRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var client = GetClient(model.Auth.ClientID, model.Auth.ClientKey);

                if (client != null)
                {
                    var token = dataProtector.Protect($"{model.Auth.ClientID}_{model.Auth.ClientKey}_{model.GameId}_{model.SiteName}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                    var redirectUrl = Url.Action("Auth", "GameRoundResult", new { culture = model.Language, token }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);
                    return Ok(new GameRoundResultAccessUrlResultModel { RedirectUrl = redirectUrl });
                }
            }

            var sentryMessage = new StringBuilder();
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    sentryMessage.Append($" {error.ErrorMessage}");
                }
            }

            SentrySdk.CaptureMessage($"GetAccessURL Failed: {sentryMessage}");

            return BadRequest();
        }

        [Route("{culture=vi-VN}/[controller]/[action]/{token}", Order = 0)]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(string token)
        {
            try
            {
                var data = dataProtector.Unprotect(token).Split('_');
                var clientId = data[0];
                var clientKey = data[1];
                var siteName = data[3];
                var client = GetClient(clientId, clientKey);

                if (client != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, client.Name),
                        new Claim(CustomClaimTypes.TimeZone, client.TimeZone),
                        new Claim(CustomClaimTypes.SiteName, siteName)
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

                    var gameType = Enum.Parse<GameType>(data[2]);

                    return Enum.IsDefined(typeof(GameType), gameType) ? RedirectToAction("Index", new { gameType }) : RedirectToAction("Index");
                }
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
            }

            return BadRequest();
        }

        private AuthenticationClient GetClient(string clientId, string clientKey)
        {
            return clients.FirstOrDefault(x => x.Key == clientKey && clientId == x.Name);
        }
    }
}