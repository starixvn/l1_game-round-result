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
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
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

        protected async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int playerId, bool freeBet, string collectionName, string operatorId,
            Expression<Func<T, bool>> filter = null) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.PlayerId == playerId && bet.RoundId == roundId 
            && (!bet.FreeBet.HasValue || bet.FreeBet == freeBet) && bet.OperatorId == operatorId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected virtual async Task<IEnumerable<T>> GetBetLogsAsync<T>(long roundId, int playerId, string collectionName, string operatorId, 
            Expression<Func<T, bool>> filter = null) where T : BaseBetLogEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.PlayerId == playerId && bet.RoundId == roundId && bet.OperatorId == operatorId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
            => await database.GetCollection<T>(collectionName).Find(x => x.Round == roundId).FirstOrDefaultAsync();

        public virtual async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var one = (await GetBetsAsync<TOneEntity>(roundId, playerId, freeBet, Document.GetCollectionName(typeof(TOneEntity)), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<TBetEntity>(roundId, playerId, Document.GetCollectionName(typeof(TBetEntity)), operatorId);

            return (round, bets, one);
        }

        public virtual async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var bet = (await GetBetsAsync<TBetEntity>(roundId, playerId, freeBet, Document.GetCollectionName(typeof(TBetEntity)), operatorId)).FirstOrDefault();

            return (round, bet);
        }
    }
}