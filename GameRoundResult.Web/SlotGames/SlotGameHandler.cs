using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.SlotGames.ViewModels;
using Microsoft.Extensions.Options;

namespace GameRoundResult.Web.SlotGames.Handlers
{
    public class SlotGameHandler : IGameTicketAccessor
    {
        private readonly ISlotGameTicketService slotGameTicketService;
        private readonly IMapper mapper;
        private readonly GameResource gameResource;

        public SlotGameHandler(
            ISlotGameTicketService gameBetService,
            IMapper mapper,
            IOptions<GameResource> gameResourceOptions)
        {
            this.slotGameTicketService = gameBetService;
            this.mapper = mapper;
            gameResource = gameResourceOptions.Value;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = request.GameConfigs;
            var result = await slotGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new ClassicSlotTicketViewModel
            (
                gameConfigs.Name,
                gameConfigs.SlotsConfig?.Jackpot?.Enabled ?? false,
                request.SystemType
            )
            {
                StaticResourceUrl = gameResource.BaseUrl.ToString()
            };

            if (result != null)
            {
                viewModel.RoundResult = mapper.Map<ClassicSlotRoundResultViewModel>(result);
                viewModel.RoundResult.TimeZone = request.TimeZoneInfo;
            }

            return viewModel;
        }
    }
}