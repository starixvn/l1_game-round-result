using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Handlers;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.ViewFactory;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IPartnerRequestAuthentication partnerRequestAuthentication;
        private readonly bool enableTolgee;
        private readonly IGeneralGameSettingService generalGameSettingService;
        private readonly CloudServiceConfig cloudServiceConfig;
        private readonly IServiceProvider serviceProvider;

        public GameRoundResultController(IMediator mediator,
            GameTypeLocalization gameTypeLocalization,
            IOptions<List<AuthenticationClient>> clientOptions,
            IOptions<HostConfiguration> hostConfigurationOptions,
            IDataProtectionProvider dataProtectionProvider,
            IPartnerRequestAuthentication partnerRequestAuthentication,
            IConfiguration configuration,
            IGeneralGameSettingService generalGameSettingService,
            CloudServiceConfig cloudServiceConfig,
            IServiceProvider serviceProvider)
        {
            this.mediator = mediator;
            this.gameTypeLocalization = gameTypeLocalization;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            clients = clientOptions.Value;
            hostConfiguration = hostConfigurationOptions.Value;
            this.partnerRequestAuthentication = partnerRequestAuthentication;
            enableTolgee = bool.Parse(configuration["EnableTolgee"]);
            this.generalGameSettingService = generalGameSettingService;
            this.cloudServiceConfig = cloudServiceConfig;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GameType gameType)
        {
            var clientName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var gameTypes = clientName == "Game Admin 2" ? await gameTypeLocalization.GetGameList() : await gameTypeLocalization.GetGameListAsync(
                    User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.SiteName)?.Value,
                    User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.PartnerId)?.Value
                    );

            var viewModel = new GameRoundResultViewModel
            {
                GameTypes = gameTypes,
                GameType = gameType,
                Language = Thread.CurrentThread.CurrentCulture.Name,
                EnableTolgee = enableTolgee
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoundResult(GameType gameType, [FromServices] IRoundResultViewFactory viewFactory)
        {
            var isCrashGame = await generalGameSettingService.IsCrashGame((int)gameType);
            if (Enum.IsDefined(typeof(GameType), gameType))
            {
                return PartialView(viewFactory.GetView(gameType, isCrashGame));
            }

            throw new ArgumentException("Invalid game type", nameof(gameType));
        }

        [ResponseCache(Duration = dataCacheDuration, VaryByQueryKeys = new[] { "start", "length", "gameType", "roundId", "userTimeZone", "date" })]
        public async Task<IActionResult> GetData(int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date,
            [FromServices] IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, bool requestFromHistoryService)
        {
            if (cloudServiceConfig?.ShouldCallOnPremiseService((int)gameType) == true && !requestFromHistoryService)
            {
                return await GetRemoteData(start, length, gameType, roundId, userTimeZone, date);
            }

            return await GetInternalData(start, length, gameType, roundId, userTimeZone, date, stringLocalizer);
        }

        private async Task<IActionResult> GetInternalData(int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            var result = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo, start, length));

            var data = result.Item2.Select(x => x.ToDataTableArray(stringLocalizer));

            return Json(new RoundResultPagingViewModel
            {
                Data = data,
                RecordsFiltered = result.Item1,
                RecordsTotal = result.Item1
            });
        }

        private async Task<IActionResult> GetRemoteData(int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date)
        {
            var mainResultApi = serviceProvider.GetService<IMainResultApi>();
            var clientKey = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.ClientKey)?.Value;
            var clientId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            try
            {
                var roundResultByGame = await mainResultApi.GetRoundResultByGame(new GetRoundResultByGameRequest
                {
                    Start = start,
                    GameType = gameType,
                    Auth = new GameRoundResultAuthModel
                    {
                        ClientID = clientId,
                        ClientKey = clientKey
                    },
                    Date = date,
                    Length = length,
                    RoundId = roundId,
                    UserTimeZone = userTimeZone
                });

                return Json(roundResultByGame);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return BadRequest();
            }
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetRemoteData(
            GetRoundResultByGameRequest request,
            [FromServices] IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var client = GetClient(request.Auth.ClientID, request.Auth.ClientKey);
            var authorize = await partnerRequestAuthentication.Authorize(request.Auth.OperatorId, Request, request.Auth.OperatorSecret);

            return client == null && !authorize ?
                BadRequest() :
                await GetData(request.Start, request.Length, request.GameType, request.RoundId, request.UserTimeZone, request.Date, stringLocalizer, true);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccessUrl([FromBody] GameRoundResultAccessUrlRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var client = GetClient(model.Auth.ClientID, model.Auth.ClientKey);
                if (client != null)
                {
                    var token = dataProtector.Protect($"{model.Auth.ClientID}^^{model.Auth.ClientKey}^^{model.GameId}^^{model.SiteName}^^{model.PartnerId}^^{model.CurrencyGroupId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                    model.Language = StandardizeLanguage(model.Language);
                    var redirectUrl = Url.Action("Auth", "GameRoundResult", new { culture = model.Language, token }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);
                    return Ok(new GameRoundResultAccessUrlResultModel { RedirectUrl = redirectUrl });
                }

                var authorize = await partnerRequestAuthentication.Authorize(model.Auth.OperatorId, Request, model.Auth.OperatorSecret);
                if (authorize)
                {
                    var token = dataProtector.Protect($"{model.Auth.OperatorId}^^{model.Auth.OperatorSecret}^^{model.GameId}^{model.SiteName}^^{model.PartnerId}^^{model.CurrencyGroupId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                    model.Language = StandardizeLanguage(model.Language);
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

        private string StandardizeLanguage(string language)
        {
            if (language == "zh-CN")
            {
                return "zh-Hans";
            }
            if (language == "zh-TW")
            {
                return "zh-Hant";
            }
            return language;
        }

        [Route("{culture=vi-VN}/[controller]/[action]/{token}", Order = 0)]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(string token)
        {
            try
            {
                var data = dataProtector.Unprotect(token).Split("^^");
                var clientId = data[0];
                var clientKey = data[1];
                var siteName = data[3];
                var partnerId = data[4];
                var currencyGroupId = data[5];
                var client = GetClient(clientId, clientKey);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, client.Name),
                        new Claim(CustomClaimTypes.TimeZone, client.TimeZone),
                        new Claim(CustomClaimTypes.SiteName, siteName),
                        new Claim(CustomClaimTypes.PartnerId, partnerId),
                        new Claim(CustomClaimTypes.CurrencyGroupId, currencyGroupId),
                        new Claim(CustomClaimTypes.ClientKey, clientKey),
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