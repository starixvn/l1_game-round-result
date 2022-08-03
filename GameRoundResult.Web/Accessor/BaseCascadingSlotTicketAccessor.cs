namespace GameRoundResult.Web.Accessor
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using GameRoundResult.Core.Database.Entities;
    using GameRoundResult.Core.Services;
    using GameRoundResult.Web.Extensions;
    using GameRoundResult.Web.Models;
    using GameRoundResult.Web.Requests;

    public class BaseCascadingSlotTicketAccessor<SlotRound, ToalMultiplier> : IGameTicketAccessor
        where SlotRound : BaseCascadingSlotRoundEntity
        where ToalMultiplier : BaseCascadingSlotTotalMultiplierEntity
    {
        private readonly IBaseCascadingSlotTicketService gameBetService;
        private readonly IMapper mapper;

        public BaseCascadingSlotTicketAccessor(IBaseCascadingSlotTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SlotRound, ToalMultiplier>(request.RoundId, request.PlayerId, request.OperatorId);

            return new BaseCascadingSlotTicketViewModel
            {
                Round = result.Item1?.ToViewModel<SlotRound, BaseCascadingSlotRoundViewModel>(mapper, request.TimeZoneInfo),
                Multipliers = result.Item2?.Rounds.Select(multiplier => multiplier.ToViewModel(mapper, request.TimeZoneInfo)),
            };
        }
    }
}
