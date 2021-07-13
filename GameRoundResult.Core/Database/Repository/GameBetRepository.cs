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
    public interface IGameBetRepository
    {
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;
    }

    public class GameBetRepository : IGameBetRepository
    {
        protected readonly IMongoDatabase database;

        public GameBetRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        protected async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int memberId, bool freeBet, string collectionName, Expression<Func<T, bool>> filter = null) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.MemberId == memberId && bet.Round == roundId && (bet.FreeBet.HasValue || bet.FreeBet == freeBet);

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected async Task<IEnumerable<T>> GetBetLogsAsync<T>(long roundId, int memberId, string collectionName, Expression<Func<T, bool>> filter = null) where T : BaseBetLogEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.MemberId == memberId && bet.Round == roundId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
            => await database.GetCollection<T>(collectionName).Find(x => x.Round == roundId).FirstOrDefaultAsync();

        public virtual async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var one = (await GetBetsAsync<TOneEntity>(roundId, memberId, freeBet, Document.GetCollectionName(typeof(TOneEntity)))).FirstOrDefault();
            var bets = await GetBetLogsAsync<TBetEntity>(roundId, memberId, Document.GetCollectionName(typeof(TBetEntity)));

            return (round, bets, one);
        }

        public virtual async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var bet = (await GetBetsAsync<TBetEntity>(roundId, memberId, freeBet, Document.GetCollectionName(typeof(TBetEntity)))).FirstOrDefault();

            return (round, bet);
        }
    }
}