using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class NightClubEndRoundInfoService : RoundOnlyEndGameInfoService<NightClubRound>, IEndGameInfoService
    {
        public NightClubEndRoundInfoService(IMongoDatabase database)
            : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
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

            return new EndRoundInfoResult
            {
                EndTime = round.EndTime,
                ValidBetAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalWin = round.BetWin
            };
        }

        protected override Expression<Func<NightClubRound, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
#pragma warning disable S1067 // Expressions should not be too complex
            => (round) => round.RoundId == request.GameRoundId && round.PlayerId == request.PlayerId && round.SiteId == request.SiteId
            && (round.PartnerId == request.OperatorId || round.OperatorId == request.OperatorId);
#pragma warning restore S1067 // Expressions should not be too complex
    }
}
