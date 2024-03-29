using GameRoundResult.Core.Database.Entities.NextBall;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class NextBall1EndGameInfoService: BaseDrawEndGameInfoService<NextBall1Round, NextBall1Bet, NextBallRoundResult, NextBallSettlementResult>
    {
        public NextBall1EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }

    public class NextBall2EndGameInfoService : BaseDrawEndGameInfoService<NextBall2Round, NextBall2Bet, NextBallRoundResult, NextBallSettlementResult>
    {
        public NextBall2EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}