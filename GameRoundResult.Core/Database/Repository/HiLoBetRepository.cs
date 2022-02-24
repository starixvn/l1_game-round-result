using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IHiLoBetRepository
    {
        Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId);
    }

    public class HiLoBetRepository : GameBetRepository, IHiLoBetRepository
    {
        public HiLoBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId)
        {
            var round = await database.GetCollection<HiLoRound>(Document.GetCollectionName(typeof(HiLoRound)))
                .Find(x => x.Round == roundId && x.MemberId == memberId && x.PartnerId == parterId)
                .FirstOrDefaultAsync();

            if (round != null)
            {
                var betLogs = await GetBetLogsAsync<HiLoBetLog>(roundId, memberId, Document.GetCollectionName(typeof(HiLoBetLog)), parterId, x => x.RoundId == roundId);

                return (round, betLogs);
            }

            return (null, Enumerable.Empty<HiLoBetLog>());
        }

        protected override async Task<IEnumerable<T>> GetBetLogsAsync<T>(long roundId, int memberId, string collectionName, string partnerId, Expression<Func<T, bool>> filter = null)
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.MemberId == memberId && bet.PartnerId == partnerId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .ToListAsync();
        }
    }
}