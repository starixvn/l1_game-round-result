using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ITreasureIslandTicketService
    {
        Task<TreasureIslandRound> GetAsync(long roundId, int memberId);
    }

    public class TreasureIslandTicketService : ITreasureIslandTicketService
    {
        private readonly ITreasureIslandBetRepository repository;

        public TreasureIslandTicketService(ITreasureIslandBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TreasureIslandRound> GetAsync(long roundId, int memberId)
        {
            return await repository.GetAsync(roundId, memberId);
        }
    }
}