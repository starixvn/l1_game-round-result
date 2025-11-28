using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services.EndRoundInfo
{
    public class LudoEndGameInfoService : BaseEndGameInfoService<LudoRound, LudoBet>, IEndGameInfoService
    {
        public LudoEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Big + x.Small + x.Even + x.Odd + x.Kick + x.NoKick + x.GoStable + x.NoStable + x.Release + x.NoRelease + x.Move + x.NoMove);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<LudoBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}
