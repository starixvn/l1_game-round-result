using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRoundResult.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class EndRoundInfoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IPartnerService partnerService;

        public EndRoundInfoController(IMediator mediator, IPartnerService partnerService)
        {
            this.mediator = mediator;
            this.partnerService = partnerService;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Requests.RetrieveEndRoundInfoRequest request)
        {
            var @operator = await partnerService.Get(request.Auth?.OperatorId, request.Auth?.OperatorSecret);

            if (@operator != null)
            {
                return Ok(await mediator.Send(request));
            }

            return BadRequest();
        }
    }
}