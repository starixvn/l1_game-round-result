using GameRoundResult.Core.Database.Entities.BacBall;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class BacBallEndGameInfoService : BaseEndGameInfoService<BacBallRound, BacBallBet>, IEndGameInfoService
    {
        public BacBallEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Player + x.Banker);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override async Task<BacBallRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var roundEntity = await roundCollection.Find(x => x.DrawId != 1).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected override Expression<Func<BacBallBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.DrawId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.Paid;
    }
}