using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class FortuneCatEndGameInfoService : RoundOnlyEndGameInfoService<FortuneCatRound>, IEndGameInfoService
    {
        public FortuneCatEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);

            if (round == null)
            {
                return EndGameInfoError.SB1001;
            }

            if (!round.Paid)
            {
                return EndGameInfoError.SB1005;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.EndTime,
                ValidBetAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalWin = round.BetWin
            };
        }

        protected override Expression<Func<FortuneCatRound, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
            => (round) => round.RoundId == request.GameRoundId
            && round.PlayerId == request.PlayerId
            && round.SiteId == request.SiteId
            && round.OperatorId == request.OperatorId;
    }
}