using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBitcoinMasterBetRepository
    {
        Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int playerId, string operatorId);
    }

    public class BitcoinMasterBetRepository : GameBetRepository, IBitcoinMasterBetRepository
    {
        public BitcoinMasterBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int playerId, string operatorId)
        {
            var round = await GetRoundAsync<BitcoinMasterRound>(roundId, Document.GetCollectionName(typeof(BitcoinMasterRound)));
            var one = (await GetBetsAsync<BitcoinMasterOne>(roundId, playerId, Document.GetCollectionName(typeof(BitcoinMasterOne)), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<BitcoinMasterBet>(roundId, playerId, Document.GetCollectionName(typeof(BitcoinMasterBet)), operatorId);

            return (round, bets, one);
        }

        private async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int playerId, string collectionName, string operatorId) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.PlayerId == playerId && bet.RoundId == roundId && bet.OperatorId == operatorId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(defaultExpression)
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}