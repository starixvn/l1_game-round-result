using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class CasinoHoldemPokerEndGameInfoService :
        BaseEndGameInfoService<CasinoHoldemPokerRound, CasinoHoldemPokerBet>, IEndGameInfoService
    {
        public CasinoHoldemPokerEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
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

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount,
                TotalAmount = amount,
                TotalWin = bet.Betwin
            };
        }

        protected override Expression<Func<CasinoHoldemPokerBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
        {
#pragma warning disable S1067 // Expressions should not be too complex
            return (bet) => (bet.RoundId == request.GameRoundId || bet.Phien == request.GameRoundId)
            && (bet.PlayerId == request.PlayerId || bet.MemberId == request.PlayerId)
            && bet.SiteId == request.SiteId;
#pragma warning restore S1067 // Expressions should not be too complex
        }
    }
}