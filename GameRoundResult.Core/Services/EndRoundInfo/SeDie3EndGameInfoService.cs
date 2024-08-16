using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SeDie3EndGameInfoService : BaseEndGameInfoService<SeDie3Round, SeDie3Bet>, IEndGameInfoService
    {
        public SeDie3EndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Red + x.White + x.ThreeRed + x.OneRed + x.ThreeWhite + + x.TwoRed);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<SeDie3Bet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}