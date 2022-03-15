
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class CasinoHoldemPokerEndGameInfoService :
        BaseEndGameInfoService<CasinoHoldemPokerRound, CasinoHoldemPokerBet>, IEndGameInfoService
    {
        public CasinoHoldemPokerEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndGameInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var bets = await GetBetsAsync(request);

            if (!bets.Any())
            {
                return EndGameInfoError.SB1001;
            }

            var round = await GetRoundAsync(request.GameRoundId);
            if (!round.Ended)
            {
                return EndGameInfoError.SB1005;
            }

            var bet = bets.FirstOrDefault();
            var amount = bet.Aa + bet.Ante + bet.Call;

            return new EndGameInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount,
                TotalAmount = amount,
                TotalWin = bet.Betwin
            };
        }

        protected override Expression<Func<CasinoHoldemPokerBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
        {
            return (bet) => bet.RoundId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.SiteId == request.SiteId;
        }
    }
}
