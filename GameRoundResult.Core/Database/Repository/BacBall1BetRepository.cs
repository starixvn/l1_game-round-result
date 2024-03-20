using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall1;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBacBall1BetRepository
    {
        Task<(BacBall1Round, BacBall1Bet, IEnumerable<BacBall1BetLog>)> GetAsync(long handId, int playerId, string operatorId);
    }
    public class BacBall1BetRepository : GameBetRepository, IBacBall1BetRepository
    {
        public BacBall1BetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BacBall1Round, BacBall1Bet, IEnumerable<BacBall1BetLog>)> GetAsync(long drawId, int playerId, string operatorId)
        {
            var bet = await GetCollection<BacBall1Bet>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();
            var betLogs = await GetCollection<BacBall1BetLog>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .ToListAsync();

            var roundFilter = Builders<BacBall1Round>.Filter.ElemMatch(x => x.Result, y => y.DrawId == drawId);
            var round = await GetCollection<BacBall1Round>().Find(roundFilter).FirstOrDefaultAsync();

            return (round, bet, betLogs);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(Document.GetCollectionName(typeof(T)));
        }
    }
}