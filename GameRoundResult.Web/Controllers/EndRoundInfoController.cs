using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRoundResult.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class EndRoundInfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public EndRoundInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Requests.RetrieveEndRoundInfoRequest request)
        {
            var endRoundInfoResult = await mediator.Send(request);

            if (endRoundInfoResult.IsAuthenticated)
            {
                return Ok(endRoundInfoResult);
            }

            return BadRequest();
        }
    }
}