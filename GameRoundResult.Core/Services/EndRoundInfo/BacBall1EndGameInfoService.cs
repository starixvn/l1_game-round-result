using GameRoundResult.Core.Database.Entities.BacBall1;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class BacBall1EndGameInfoService : BaseEndGameInfoService<BacBall1Round, BacBall1Bet>, IEndGameInfoService
    {
        public BacBall1EndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Player + x.Banker + x.Tie);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override async Task<BacBall1Round> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var roundEntity = await roundCollection.Find(x => x.DrawId != 1).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected override Expression<Func<BacBall1Bet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.DrawId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.Paid;
    }
}