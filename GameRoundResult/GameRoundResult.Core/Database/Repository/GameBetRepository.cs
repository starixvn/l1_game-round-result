using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public class GameBetRepository
    {
        private readonly IMongoDatabase database;

        public GameBetRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmall(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BigSmallRound>(roundId, MiniGameRoundCollections.BigSmallRound);
            var bets = await GetBetsAsync<BigSmallBet>(roundId, memberId, MiniGameBetCollections.BigSmallBet);

            return (round, bets);
        }

        private async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int memberId, string collectionName) where T: BaseBetEntity
        {
            return await database.GetCollection<T>(collectionName).Find(x => x.MemberId == memberId && x.Round == roundId).ToListAsync();
        }

        private async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
        {
            return await database.GetCollection<T>(collectionName).Find(x =>  x.Round == roundId).FirstOrDefaultAsync();
        }
    }
}