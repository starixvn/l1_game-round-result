namespace GameRoundResult.Core.Services
{
    using System.Threading.Tasks;
    using GameRoundResult.Core.Database.Entities;
    using GameRoundResult.Core.Database.Repository;

    public interface IBaseCascadingSlotTicketService
    {
        Task<(SlotRound, TotalMultiplier)> GetAsync<SlotRound, TotalMultiplier>(long roundId, int playerId) 
            where SlotRound : BaseCascadingSlotRoundEntity where TotalMultiplier : BaseCascadingSlotTotalMultiplierEntity;
    }

    public class BaseCascadingSlotTicketService : IBaseCascadingSlotTicketService
    {
        private readonly IBaseCascadingSlotBetRepository repository;

        public BaseCascadingSlotTicketService(IBaseCascadingSlotBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(SlotRound, TotalMultiplier)> GetAsync<SlotRound, TotalMultiplier>(long roundId, int playerId)
            where SlotRound : BaseCascadingSlotRoundEntity
            where TotalMultiplier : BaseCascadingSlotTotalMultiplierEntity => await repository.GetAsync<SlotRound, TotalMultiplier>(roundId, playerId);
    }
}
