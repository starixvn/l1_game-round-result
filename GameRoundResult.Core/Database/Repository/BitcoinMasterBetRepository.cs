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
        Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int memberId, string partnerId);
    }

    public class BitcoinMasterBetRepository : GameBetRepository, IBitcoinMasterBetRepository
    {
        public BitcoinMasterBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int memberId, string partnerId)
        {
            var round = await GetRoundAsync<BitcoinMasterRound>(roundId, Document.GetCollectionName(typeof(BitcoinMasterRound)));
            var one = (await GetBetsAsync<BitcoinMasterOne>(roundId, memberId, Document.GetCollectionName(typeof(BitcoinMasterOne)), partnerId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<BitcoinMasterBet>(roundId, memberId, Document.GetCollectionName(typeof(BitcoinMasterBet)), partnerId);

            return (round, bets, one);
        }

        private async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int memberId, string collectionName, string partnerId) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.MemberId == memberId && bet.Round == roundId && bet.PartnerId == partnerId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(defaultExpression)
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}