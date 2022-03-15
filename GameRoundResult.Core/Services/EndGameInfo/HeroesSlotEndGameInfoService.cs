using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class HeroesSlotEndGameInfoService : RoundOnlyEndGameInfoService<HeroesSlotRound>, IEndGameInfoService
    {
        public HeroesSlotEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndGameInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
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

            return new EndGameInfoResult
            {
                EndTime = round.EndTime,
                ValidBetAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalWin = round.BetWin
            };
        }

        protected override Expression<Func<HeroesSlotRound, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
            => (round) => round.Round == request.GameRoundId && round.PlayerId == request.PlayerId && round.SiteId == request.SiteId;
    }
}