using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Filters;
using GameRoundResult.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameRoundResult.Web.Controllers
{
    [TypeFilter(typeof(DevOnlyAttribute))]
    public class DemoController : Controller
    {
        private readonly IPartnerService operatorService;

        public DemoController(IPartnerService operatorService)
        {
            this.operatorService = operatorService;
        }

        [Route("[controller]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new DemoViewModel { Operators = await operatorService.GetAll() });
        }

        [HttpPost]
        public async Task<IActionResult> GetRequestParam(DemoViewModel model)
        {
            var _operator = await operatorService.GetById(model.OperatorId);
            if (_operator != null)
            {
                var param = new
                {
                    FreeBet = model.FreeBet,
                    GameRoundId = model.GameRoundId,
                    GameTypeId = model.GameTypeId,
                    PlayerId = model.PlayerId,
                    Language = model.Language,
                    SiteId = model.SiteId,
                    Auth = new AuthModel
                    {
                        OperatorId = model.OperatorId,
                        OperatorSecret = _operator.SecretKey
                    }
                };
                return Json(JsonConvert.SerializeObject(param));
            }
            return BadRequest();
        }
    }
}