using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class RouletteSTicketViewModel : GameTicketViewModel
    {
        public RouletteSRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<RouletteBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal BetWin { get; set; }

        public decimal WinLoss => BetWin - TotalBet;
    }

    public class RouletteSBetViewModel : RouletteBetViewModel
    { }
}
