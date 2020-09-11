using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieTicketViewModel : GameTicketViewModel
    {
        public VipSeDieRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<VipSeDieBetViewModel> Bets { get; set; }

        public decimal TotalBet => Bets.Sum(x => x.Amount);

        public decimal BetWin { get; set; }

        public decimal WinLoss => BetWin - TotalBet;
    }

    public class VipSeDieBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}