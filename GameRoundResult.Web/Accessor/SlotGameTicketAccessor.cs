using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class SlotGameTicketAccessor : IGameTicketAccessor
    {
        private readonly ISlotGameTicketService slotGameTicketService;
        private readonly IGameConfigsService gameConfigsService;
        private readonly IMapper mapper;

        public SlotGameTicketAccessor(ISlotGameTicketService gameBetService, IGameConfigsService gameConfigsService, IMapper mapper)
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

            var viewModel = new SlotGameTicketViewModel
            (
                gameConfigs.Name,
                gameConfigs.SlotsConfig.Jackpot.Enabled,
                request.SystemType
            );

            if (result != null)
            {
                viewModel.RoundResult = mapper.Map<SlotGameRound, SlotGameRoundResultViewModel>(result);
                viewModel.RoundResult.TimeZone = request.TimeZoneInfo;
            }

            return viewModel;
        }
    }
}