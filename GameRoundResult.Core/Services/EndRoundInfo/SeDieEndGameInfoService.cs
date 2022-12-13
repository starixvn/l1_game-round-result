using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SeDieEndGameInfoService : BaseEndGameInfoService<SeDieRound, SeDieBet>, IEndGameInfoService
    {
        public SeDieEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Odd + x.Even + x.ThreeRed + x.FourRed + x.ThreeWhite + x.FourWhite + x.TwoRed);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<SeDieBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}