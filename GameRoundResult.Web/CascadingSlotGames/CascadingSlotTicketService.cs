namespace GameRoundResult.Web.CascadingSlotGames
{
    using System.Threading.Tasks;
    using GameRoundResult.Core.Database.Entities;
    using GameRoundResult.Core.Database.Repository;

    public interface ICascadingSlotTicketService
    {
        Task<(BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity)> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class CascadingSlotTicketService : ICascadingSlotTicketService
    {
        private readonly ICascadingSlotBetRepository repository;

        public CascadingSlotTicketService(ICascadingSlotBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity)> GetAsync(long roundId, string playerId, string operatorId, string gameName)
            => await repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}