using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.SlotGames.Handlers
{
    public class SlotGameHandler : IGameTicketAccessor
    {
        private readonly ISlotGameTicketService slotGameTicketService;
        private readonly IGameConfigsService gameConfigsService;
        private readonly IMapper mapper;

        public SlotGameHandler(ISlotGameTicketService gameBetService, IGameConfigsService gameConfigsService, IMapper mapper)
        {
            this.slotGameTicketService = gameBetService;
            this.gameConfigsService = gameConfigsService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = await gameConfigsService.GetByIdAsync((int)request.GameType);

            if (gameConfigs == null)
            {
                return null;
            }

            var result = await slotGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new ClassicSlotTicketViewModel
            (
                gameConfigs.Name,
                gameConfigs.SlotsConfig.Jackpot.Enabled,
                request.SystemType
            );

            if (result != null)
            {
                viewModel.RoundResult = mapper.Map<SlotGameRound, ClassicSlotRoundResultViewModel>(result);
                viewModel.RoundResult.TimeZone = request.TimeZoneInfo;
            }

            return viewModel;
        }
    }
}