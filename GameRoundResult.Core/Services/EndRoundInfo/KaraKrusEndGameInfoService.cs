using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services.EndRoundInfo
{
    public class KaraKrusEndGameInfoService : BaseEndGameInfoService<KaraKrusRound, KaraKrusBet>, IEndGameInfoService
    {
        public KaraKrusEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Kara + x.Krus + x.ThreeHead + x.ThreeTail + x.TwoHead + +x.OneHead);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalAmount = request.FreeBet ? 0 : totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override Expression<Func<KaraKrusBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}
