using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBacBallBetRepository
    {
        Task<(BacBallRound, BacBallBet, IEnumerable<BacBallBetLog>)> GetAsync(long handId, int playerId, string operatorId);
    }
    public class BacBallBetRepository : GameBetRepository, IBacBallBetRepository
    {
        public BacBallBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BacBallRound, BacBallBet, IEnumerable<BacBallBetLog>)> GetAsync(long drawId, int playerId, string operatorId)
        {
            var bet = await GetCollection<BacBallBet>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();
            var betLogs = await GetCollection<BacBallBetLog>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .ToListAsync();

            var roundFilter = Builders<BacBallRound>.Filter.ElemMatch(x => x.Result, y => y.DrawId == drawId);
            var round = await GetCollection<BacBallRound>().Find(roundFilter).FirstOrDefaultAsync();

            return (round, bet, betLogs);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(Document.GetCollectionName(typeof(T)));
        }
    }
}