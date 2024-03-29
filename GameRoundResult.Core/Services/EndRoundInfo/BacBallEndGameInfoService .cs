using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BacBall1EndGameInfoService : BaseDrawEndGameInfoService<BacBall1Round, BacBall1Bet, BacBallRoundResult, BacBallSettlementResult>
    {
        public BacBall1EndGameInfoService(IMongoDatabase database) : base(database) { }
    }

    public class BacBall2EndGameInfoService : BaseDrawEndGameInfoService<BacBall2Round, BacBall2Bet, BacBallRoundResult, BacBallSettlementResult>
    {
        public BacBall2EndGameInfoService(IMongoDatabase database) : base(database) { }
    }
}