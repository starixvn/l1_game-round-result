using GameRoundResult.Core.Database.Entities.BacBall1;
using GameRoundResult.Core.Database.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public interface IBacBall1TicketService
    {
        Task<(BacBall1Round, BacBall1Bet, IEnumerable<BacBall1BetLog>)> GetAsync(long drawId, int playerId, string operatorId);
    }

    public class BacBall1TicketService : IBacBall1TicketService
    {
        private readonly IBacBall1BetRepository repository;

        public BacBall1TicketService(IBacBall1BetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BacBall1Round, BacBall1Bet, IEnumerable<BacBall1BetLog>)> GetAsync(long drawId, int playerId, string operatorId)
        {
            return await repository.GetAsync(drawId, playerId, operatorId);
        }
    }
}