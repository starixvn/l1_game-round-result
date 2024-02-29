using System;
using System.Threading.Tasks;
using GameRoundResult.Web._Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace GameRoundResult.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class EndRoundInfoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IPartnerRequestAuthentication partnerRequestAuthentication;

        public EndRoundInfoController(IMediator mediator, IPartnerRequestAuthentication partnerRequestAuthentication)
        {
            this.mediator = mediator;
            this.partnerRequestAuthentication = partnerRequestAuthentication;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Requests.RetrieveEndRoundInfoRequest request)
        {
            var authenticationResult = await partnerRequestAuthentication.AuthorizeByKeyValue(request.Auth?.OperatorId, request.Auth?.OperatorSecret);            
            return authenticationResult.IsAuthorize ? Ok(await mediator.Send(request)) : BadRequest();
        }
    }
}