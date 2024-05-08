using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IBacBall1TicketService : IDrawTicketService<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult> { }
    public interface IBacBall2TicketService : IDrawTicketService<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult> { }

    public class BacBall1TicketService : DrawTicketService<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall1TicketService
    {
        public BacBall1TicketService(IBacBall1BetRepository repository) : base(repository) { }
    }

    public class BacBall2TicketService : DrawTicketService<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall2TicketService
    {
        public BacBall2TicketService(IBacBall2BetRepository repository) : base(repository) { }
    }
}