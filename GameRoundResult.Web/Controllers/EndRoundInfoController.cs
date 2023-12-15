using System.Threading.Tasks;
using GameRoundResult.Core._Share;
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
            request.IsAuthByAccessKey = await partnerRequestAuthentication.Verify(request.Auth?.OperatorId, Request);

            var endRoundInfoResult = await mediator.Send(request);

            if (endRoundInfoResult.IsAuthenticated)
            {
                return Ok(endRoundInfoResult);
            }

            return BadRequest();
        }
    }
}