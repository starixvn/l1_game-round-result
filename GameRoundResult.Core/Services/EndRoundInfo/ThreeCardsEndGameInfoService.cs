using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class ThreeCardsEndGameInfoService : BaseEndGameInfoService<ThreeCardsRound, ThreeCardsBet>, IEndGameInfoService
    {
        public ThreeCardsEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request, string gameName)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Red + x.Black + x.Diamonds + x.Hearts + x.Spades + x.Clubs);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<ThreeCardsBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
           => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}