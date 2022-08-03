using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class HiLoEndGameInfoService : RoundOnlyEndGameInfoService<HiLoRound>, IEndGameInfoService
    {
        public HiLoEndGameInfoService(IMongoDatabase database)
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
                ValidBetAmount = round.Amount,
                TotalAmount = round.Amount,
                TotalWin = round.Betwin
            };
        }

        protected override Expression<Func<HiLoRound, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
            => (round) => round.RoundId == request.GameRoundId && round.OperatorId == request.OperatorId && round.PlayerId == request.PlayerId;
    }
}