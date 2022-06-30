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
        Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int playerId, string operatorId);
    }

    public class HiLoBetRepository : GameBetRepository, IHiLoBetRepository
    {
        public HiLoBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int playerId, string operatorId)
        {
            var round = await database.GetCollection<HiLoRound>(Document.GetCollectionName(typeof(HiLoRound)))
                .Find(x => x.RoundId == roundId
                && (x.PlayerId == playerId || x.MemberId == playerId)
                && (x.OperatorId == operatorId || x.PartnerId == operatorId))
                .FirstOrDefaultAsync();

            if (round != null)
            {
                var betLogs = await GetBetLogsAsync<HiLoBetLog>(roundId, playerId, Document.GetCollectionName(typeof(HiLoBetLog)), operatorId, x => x.RoundId == roundId);

                return (round, betLogs);
            }

            return (null, Enumerable.Empty<HiLoBetLog>());
        }

        protected override async Task<IEnumerable<T>> GetBetLogsAsync<T>(long roundId, int playerId, string collectionName, string operatorId, Expression<Func<T, bool>> filter = null)
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
                (bet.PlayerId == playerId || bet.MemberId == playerId)
                && (bet.OperatorId == operatorId || bet.PartnerId == operatorId);

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .ToListAsync();
        }
    }
}