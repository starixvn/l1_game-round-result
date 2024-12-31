using GameRoundResult.Core.Database.Entities.BacBall;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBacBall2BetRepository : IDrawBetRepository<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult> { }

    public interface IBacBall1BetRepository : IDrawBetRepository<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult> { }
    public interface IBaccaratNumberBetRepository : IDrawBetRepository<BaccaratNumberRound, BaccaratNumberBet, BaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult> { }
    public interface ISpeedBaccaratNumberBetRepository : IDrawBetRepository<SpeedBaccaratNumberRound, SpeedBaccaratNumberBet, SpeedBaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult> { }
    public interface IVIPBaccaratNumberBetRepository : IDrawBetRepository<VIPBaccaratNumberRound, VIPBaccaratNumberBet, VIPBaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult> { }

    public class BacBall1BetRepository : DrawBetRepository<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall1BetRepository
    {
        public BacBall1BetRepository(IMongoDatabase database) : base(database) { }
    }

    public class BacBall2BetRepository : DrawBetRepository<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall2BetRepository
    {
        public BacBall2BetRepository(IMongoDatabase database) : base(database) { }
    }

    public class BaccaratNumberBetRepository : DrawBetRepository<BaccaratNumberRound, BaccaratNumberBet, BaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult>, IBaccaratNumberBetRepository
    {
        public BaccaratNumberBetRepository(IMongoDatabase database) : base(database) { }
    }

    public class SpeedBaccaratNumberBetRepository : DrawBetRepository<SpeedBaccaratNumberRound, SpeedBaccaratNumberBet, SpeedBaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult>, ISpeedBaccaratNumberBetRepository
    {
        public SpeedBaccaratNumberBetRepository(IMongoDatabase database) : base(database) { }
    }

    public class VIPBaccaratNumberBetRepository : DrawBetRepository<VIPBaccaratNumberRound, VIPBaccaratNumberBet, VIPBaccaratNumberBetLog, BacBallRoundResult, BacBallSettlementResult>, IVIPBaccaratNumberBetRepository
    {
        public VIPBaccaratNumberBetRepository(IMongoDatabase database) : base(database) { }
    }
}