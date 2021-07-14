using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class KenoSoccerTicketViewModel : GameTicketViewModel
    {
        public KenoSoccerRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<KenoSoccerBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;
    }

    public class KenoSoccerBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}