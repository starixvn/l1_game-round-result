using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public interface IEndGameInfoService
    {
        Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request);
    }

    public abstract class RoundOnlyEndGameInfoService<TRounEntity> where TRounEntity : GameRound
    {
        protected readonly IMongoCollection<TRounEntity> roundCollection;

        protected RoundOnlyEndGameInfoService(IMongoDatabase database)
        {
            roundCollection = database.GetCollection<TRounEntity>(Document.GetCollectionName(typeof(TRounEntity)));
        }

        protected virtual async Task<TRounEntity> GetRoundAsync(long gameRoundId)
        {
            var roundEntity = await roundCollection.Find(x => x.RoundId == gameRoundId).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected virtual async Task<TRounEntity> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var expression = GetRoundFilterExpression(request);
            var roundEntity = await roundCollection.Find(expression).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected virtual Expression<Func<TRounEntity, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
            => (round) => round.RoundId == request.GameRoundId;
    }

    public abstract class BaseEndGameInfoService<TRounEntity, TBetEntity> : RoundOnlyEndGameInfoService<TRounEntity> where TRounEntity : GameRound where TBetEntity : BaseBetEntity
    {
        protected readonly IMongoCollection<TBetEntity> betCollection;

        protected BaseEndGameInfoService(IMongoDatabase database) : base(database)
        {
            betCollection = database.GetCollection<TBetEntity>(Document.GetCollectionName(typeof(TBetEntity)));
        }

        protected virtual async Task<IEnumerable<TBetEntity>> GetBetsAsync(RetrieveEndGameInfoRequest request)
        {
            var expression = GetBetFilterExpression(request);
            var partnerExpression = PartnerFilterExpression(request);
            var finalExpression = expression.And(partnerExpression);

            return await betCollection.Find(finalExpression).ToListAsync();
        }

        protected virtual Expression<Func<TBetEntity, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.RoundId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.SiteId == request.SiteId && bet.Paid;

        protected virtual Expression<Func<TBetEntity, bool>> PartnerFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => string.Equals(request.OperatorId, bet.OperatorId);

        protected virtual Expression<Func<TBetEntity, bool>> FreeBetExpression(RetrieveEndGameInfoRequest request)
            => bet => !bet.FreeBet.HasValue || bet.FreeBet.Value == request.FreeBet;
    }
}