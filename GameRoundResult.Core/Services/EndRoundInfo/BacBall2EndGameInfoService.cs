using GameRoundResult.Core.Database.Entities.BacBall2;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class BacBall2EndGameInfoService : BaseEndGameInfoService<BacBall2Round, BacBall2Bet>, IEndGameInfoService
    {
        public BacBall2EndGameInfoService(IMongoDatabase database) : base(database)
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

        protected override async Task<BacBall2Round> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var roundFilter = Builders<BacBall2Round>.Filter.ElemMatch(x => x.Result, y => y.DrawId == request.GameRoundId);
            var roundEntity = await roundCollection.Find(roundFilter).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected override Expression<Func<BacBall2Bet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.DrawId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.Paid;
    }
}