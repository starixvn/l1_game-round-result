using System.Threading.Tasks;
using GameRoundResult.Web._Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var authenticationResult = await partnerRequestAuthentication.Authorize(request.Auth?.OperatorId, Request, "");

            return authenticationResult.IsAuthorize ? Ok(await mediator.Send(request)) : BadRequest();
        }
    }
}