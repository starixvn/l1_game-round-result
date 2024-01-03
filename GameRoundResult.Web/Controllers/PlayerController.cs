using System;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities.Player;
using GameRoundResult.Core.Services;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IPartnerRequestAuthentication partnerRequestAuthentication;
        private readonly ILogService logService;
        private readonly bool isVG2;

        public PlayerController(
            IMediator mediator,
            IPartnerRequestAuthentication partnerRequestAuthentication,
            ILogService logService,
            IConfiguration configuration)
        {
            this.mediator = mediator;
            this.partnerRequestAuthentication = partnerRequestAuthentication;
            this.logService = logService;
            this.isVG2 = configuration["SystemType"] == SystemType.VG2;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RetrieveEndRoundInfo([FromBody] RetrieveEndRoundInfoRequest request)
        {
            if (!isVG2)
            {
                request.FreeBet = false;
            }

            var authenticationResult = await partnerRequestAuthentication.AuthorizeByAccessKey(request.Auth?.OperatorId, Request);

            if (!authenticationResult.IsAuthorize)
            {
                return Unauthorized();
            }

            request.Auth.OperatorSecret = authenticationResult.OperatorSecret;

            var result = await mediator.Send(request);

            var clientEndRoundInfoResult = new GameRoundResult.Web.Models.Player.EndRoundInfoResult()
            {
                TotalAmount = result.TotalAmount,
                TotalWin = result.TotalWin,
                ValidBetAmount = result.ValidBetAmount,
                EndTime = result.EndTime,
                Seq = request.Seq,
                ErrorCode = result.ErrorCode,
                ErrorDescription = result.ErrorDescription
            };

            await WriteRetrieveEndRoundLog(DateTimeOffset.UtcNow, request, clientEndRoundInfoResult);

            return Ok(new SGResponse<GameRoundResult.Web.Models.Player.EndRoundInfoResult>()
            {
                TimeStamp = DateTimeOffset.UtcNow,
                Result = clientEndRoundInfoResult
            });
        }

        private Task WriteRetrieveEndRoundLog(DateTimeOffset requestTime, RetrieveEndRoundInfoRequest request, GameRoundResult.Web.Models.Player.EndRoundInfoResult result)
        {
            request.Auth.OperatorSecret = null;
            var log = new SBLog(request, result, requestTime, DateTimeOffset.UtcNow);

            return logService.LogRetrieveEndRoundAsync(log);
        }
    }
}