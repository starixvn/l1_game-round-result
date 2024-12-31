using AutoMapper;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Accessor
{
    public class BacBall1TicketAccessor : DrawTicketAccessor <IBacBall1TicketService, BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult, BacBallTicketViewModel<BacBall1Round>>
    {
        public BacBall1TicketAccessor(IBacBall1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }

    public class BacBall2TicketAccessor : DrawTicketAccessor<IBacBall2TicketService, BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult, BacBallTicketViewModel<BacBall2Round>>
    {
        public BacBall2TicketAccessor(IBacBall2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class BaccaratNumberTicketAccessor : DrawTicketAccessor<
        IBaccaratNumberTicketService, 
        BaccaratNumberRound, 
        BaccaratNumberBet, 
        BaccaratNumberBetLog, 
        BacBallRoundResult, 
        BacBallSettlementResult, 
        BacBallTicketViewModel<BaccaratNumberRound>>
    {
        public BaccaratNumberTicketAccessor(IBaccaratNumberTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class SpeedBaccaratNumberTicketAccessor : DrawTicketAccessor<
        ISpeedBaccaratNumberTicketService, 
        SpeedBaccaratNumberRound, 
        SpeedBaccaratNumberBet,
        SpeedBaccaratNumberBetLog, 
        BacBallRoundResult, 
        BacBallSettlementResult, 
        BacBallTicketViewModel<SpeedBaccaratNumberRound>>
    {
        public SpeedBaccaratNumberTicketAccessor(ISpeedBaccaratNumberTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class VIPBaccaratNumberTicketAccessor : DrawTicketAccessor<
        IVIPBaccaratNumberTicketService, 
        VIPBaccaratNumberRound, 
        VIPBaccaratNumberBet, 
        VIPBaccaratNumberBetLog, 
        BacBallRoundResult, 
        BacBallSettlementResult, 
        BacBallTicketViewModel<VIPBaccaratNumberRound>>
    {
        public VIPBaccaratNumberTicketAccessor(IVIPBaccaratNumberTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}