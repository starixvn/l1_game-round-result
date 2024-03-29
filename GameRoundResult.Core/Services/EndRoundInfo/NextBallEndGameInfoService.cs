using GameRoundResult.Core.Database.Entities.NextBall;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class NextBallEndGameInfoService<Round,Bet> : BaseEndGameInfoService<Round, Bet>, IEndGameInfoService where Round : NextBall1Round where Bet : NextBall1Bet
    {
        public NextBallEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Odd + x.Even+ x.Over + x.Under);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override async Task<Round> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var roundFilter = Builders<Round>.Filter.ElemMatch(x => x.Result, y => y.DrawId == request.GameRoundId);
            var roundEntity = await roundCollection.Find(roundFilter).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected override Expression<Func<Bet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.DrawId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.Paid;
    }

    public class NextBall1EndGameInfoService: NextBallEndGameInfoService<NextBall1Round, NextBall1Bet>
    {
        public NextBall1EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }

    public class NextBall2EndGameInfoService : NextBallEndGameInfoService<NextBall2Round, NextBall2Bet>
    {
        public NextBall2EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}