using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class Win3CardsTicketViewModel : GameTicketViewModel
    {
        public Win3CardsRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<UnbalancedBigSmallBetLogViewModel> BetLogs { get; set; }
        public Dictionary<string, decimal> Odds { get; set; }
        public decimal TotalBet { get; set; }
        public decimal BetWin { get; set; }
        public decimal WinLoss => BetWin - TotalBet;
    }
}