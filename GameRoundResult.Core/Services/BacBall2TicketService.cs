using GameRoundResult.Core.Database.Entities.BacBall2;
using GameRoundResult.Core.Database.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public interface IBacBall2TicketService
    {
        Task<(BacBall2Round, BacBall2Bet, IEnumerable<BacBall2BetLog>)> GetAsync(long drawId, string playerId, string operatorId);
    }

    public class BacBall2TicketService : IBacBall2TicketService
    {
        private readonly IBacBall2BetRepository repository;

        public BacBall2TicketService(IBacBall2BetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BacBall2Round, BacBall2Bet, IEnumerable<BacBall2BetLog>)> GetAsync(long drawId, string playerId, string operatorId)
        {
            return await repository.GetAsync(drawId, playerId, operatorId);
        }
    }
}