using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class KenoPowerEndGameInfoService<TKenoPowerRoundEntity, TKenoPowerOneEntity> : BaseEndGameInfoService<TKenoPowerRoundEntity, TKenoPowerOneEntity>, IEndGameInfoService
        where TKenoPowerRoundEntity : KenoPowerRound
        where TKenoPowerOneEntity : KenoPowerOne
    {
        public KenoPowerEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndGameInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndGameInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.TotalAmount);
            var totalBetWin = bets.Sum(x => x.Betwin);
            var totalRefund = bets.Sum(x => x.Refund);

            return new EndGameInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin > 0 ? totalBetWin + totalRefund : totalRefund
            };
        }

        protected override Expression<Func<TKenoPowerOneEntity, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
           => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}