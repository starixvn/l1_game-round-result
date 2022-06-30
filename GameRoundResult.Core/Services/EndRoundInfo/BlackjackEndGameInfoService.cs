using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BlackjackEndGameInfoService : BaseEndGameInfoService<BlackjackRound, BlackjackBet>, IEndGameInfoService
    {
        public BlackjackEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var bets = await GetBetsAsync(request);

            if (!bets.Any())
            {
                return EndGameInfoError.SB1001;
            }

            if (bets.Any(x => !x.Paid))
            {
                return EndGameInfoError.SB1005;
            }

            var round = await GetRoundAsync(bets.FirstOrDefault().RoundId);

            var totalBetAmount = bets.Sum(x => x.Bet);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<BlackjackBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.HandId == request.GameRoundId 
            && (bet.PlayerId == request.PlayerId || bet.MemberId == request.PlayerId)
            && bet.SiteId == request.SiteId;
    }
}