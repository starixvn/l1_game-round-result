using AutoMapper;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.Accessor
{
    public class BacBall1TicketAccessor : DrawTicketAccessor<IBacBall1TicketService, BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult>
    {
        public BacBall1TicketAccessor(IBacBall1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class BacBall2TicketAccessor : DrawTicketAccessor<IBacBall2TicketService, BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult>
    {
        public BacBall2TicketAccessor(IBacBall2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}