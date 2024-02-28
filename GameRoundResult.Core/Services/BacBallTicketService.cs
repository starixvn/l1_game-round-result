using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public interface IBacBallTicketService
    {
        Task<(BacBallRound, BacBallBet, IEnumerable<BacBallBetLog>)> GetAsync(long drawId, int playerId, string operatorId);
    }

    public class BacBallTicketService : IBacBallTicketService
    {
        private readonly IBacBallBetRepository repository;

        public BacBallTicketService(IBacBallBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BacBallRound, BacBallBet, IEnumerable<BacBallBetLog>)> GetAsync(long drawId, int playerId, string operatorId)
        {
            return await repository.GetAsync(drawId, playerId, operatorId);
        }
    }
}