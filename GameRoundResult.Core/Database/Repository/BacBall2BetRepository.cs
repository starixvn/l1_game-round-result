using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall2;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBacBall2BetRepository
    {
        Task<(BacBall2Round, BacBall2Bet, IEnumerable<BacBall2BetLog>)> GetAsync(long handId, string playerId, string operatorId);
    }
    public class BacBall2BetRepository : GameBetRepository, IBacBall2BetRepository
    {
        public BacBall2BetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BacBall2Round, BacBall2Bet, IEnumerable<BacBall2BetLog>)> GetAsync(long drawId, string playerId, string operatorId)
        {
            var bet = await GetCollection<BacBall2Bet>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();
            var betLogs = await GetCollection<BacBall2BetLog>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .ToListAsync();

            var roundFilter = Builders<BacBall2Round>.Filter.ElemMatch(x => x.Result, y => y.DrawId == drawId);
            var round = await GetCollection<BacBall2Round>().Find(roundFilter).FirstOrDefaultAsync();

            return (round, bet, betLogs);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(Document.GetCollectionName(typeof(T)));
        }
    }
}