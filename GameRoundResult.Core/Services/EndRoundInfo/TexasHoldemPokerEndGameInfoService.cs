using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class TexasHoldemPokerEndGameInfoService : BaseEndGameInfoService<TexasHoldemPokerRound, TexasHoldemPokerBet>, IEndGameInfoService
    {
        public TexasHoldemPokerEndGameInfoService(IMongoDatabase database)
            : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var bets = await GetBetsAsync(request);

            if (!bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var round = await GetRoundAsync(request.GameRoundId);
            if (!round.Ended)
            {
                return EndRoundInfoError.SB1005;
            }

            var bet = bets.FirstOrDefault();
            var amount = bet.Ante + bet.Call + bet.Turn + bet.River;

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount,
                TotalAmount = amount,
                TotalWin = bet.Betwin
            };
        }

        protected override Expression<Func<TexasHoldemPokerBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
        {
            return (bet) => bet.RoundId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.SiteId == request.SiteId;
        }
    }
}