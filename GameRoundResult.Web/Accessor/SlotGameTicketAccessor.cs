using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class SlotGameTicketAccessor : IGameTicketAccessor
    {
        private readonly ISlotGameTicketService slotGameTicketService;
        private readonly IGameConfigsRepository gameConfigsRepository;
        private readonly IMapper mapper;

        public SlotGameTicketAccessor(ISlotGameTicketService gameBetService, IGameConfigsRepository gameConfigsRepository, IMapper mapper)
        {
            this.slotGameTicketService = gameBetService;
            this.gameConfigsRepository = gameConfigsRepository;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = await gameConfigsRepository.GetByIdAsync((int)request.GameType);
            if (gameConfigs != null)
            {
                var result = await slotGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

                return new SlotGameTicketViewModel
                {
                    ConfigName = gameConfigs.Name,
                    EnabledJackpot = gameConfigs.SlotsConfig.Jackpot.Enabled,
                    RoundResult = result?.ToViewModel<SlotGameRound, SlotGameRoundResultViewModel>(mapper, request.TimeZoneInfo),
                    SystemType = request.SystemType
                };
            }

            return null;
        }
    }
}