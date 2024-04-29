using GameRoundResult.Core.Constants;
using GameRoundResult.Core.RoundHistory.Models;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.Requests.RoundHistory;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Controllers
{
    public class RoundHistoryController : Controller
    {
        private const string dataProtectorKey = "round-history-data-key";
        private const int dataProtectorLifeTimeSecond = 30;
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IPartnerRequestAuthentication partnerRequestAuthentication;
        private readonly ITimeLimitedDataProtector dataProtector;
        private readonly HostConfiguration hostConfiguration;       

        public RoundHistoryController(
            IMediator mediator, 
            IConfiguration configuration, 
            IPartnerRequestAuthentication partnerRequestAuthentication,
            IDataProtectionProvider dataProtectionProvider,
            IOptions<HostConfiguration> hostConfigurationOptions) {
            this.mediator = mediator;
            this.configuration = configuration;
            this.partnerRequestAuthentication = partnerRequestAuthentication;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationOptions.Value;
        }

        [Route("[controller]")]
        [HttpGet]
        public async Task<IActionResult> Index(string queryKey)
        {
            var data = dataProtector.Unprotect(queryKey).Split("^^");
            Enum.TryParse(data[5], out GameType game);
            var request = new RoundHistoryRequest
            {
                Auth = new Models.AuthModel
                {
                    OperatorId = data[0],
                    OperatorSecret = data[1]
                },
                RoundId = long.Parse(data[2]),
                ConvertToUSD = bool.Parse(data[3]),
                ExcludeBot = bool.Parse(data[4]),
                Game = game,
                ExcludeUUS = bool.Parse(data[6]),
                Nickname = data[7],
                Username = data[8],
                PartnerId = data[0]
            };
                
            var viewModel = await mediator.Send(request);
          
            return View("~/RoundHistory/Views/Index.cshtml", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetBetHistory(RoundHistoryBetLogRequest request)
        {
            var result = await mediator.Send(new GetGameTicketRequest(request.Game, request.RoundId, request.UserId, 
                TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"), request.PartnerId, false, configuration["SystemType"]));


            var viewModel = new RoundHistoryBetLogViewModel
            {
                TicketModel = result,
                BaseCurrencyMultiplier = BaseCurrencyConfig.MultiplierMapper[configuration["SystemType"]],
                BaseCurrency = BaseCurrencyConfig.CurrencyMapper[configuration["SystemType"]],
                ConvertToUSD = request.ConvertToUSD
            };
            return PartialView("~/RoundHistory/Views/_BetLog.cshtml", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccessUrl([FromBody] RoundHistoryRequest model)
        {            
            var authenticationResult = await partnerRequestAuthentication.Authorize(model.Auth.OperatorId, Request, model.Auth.OperatorSecret);
            if (authenticationResult.IsAuthorize)
            {
                var queryKey = dataProtector.Protect(
                    $"{model.Auth.OperatorId}^^{authenticationResult.OperatorSecret}^^{model.RoundId}^^{model.ConvertToUSD}^^{model.ExcludeBot}^^{model.Game}^^{model.ExcludeUUS}^^{model.Nickname}^^{model.Username}^^{model.PartnerId}",
                    TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                var redirectUrl = Url.Action("Index", "RoundHistory", new { queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);

                return Ok(redirectUrl);
            }    

            return BadRequest();
        }
    }
}
