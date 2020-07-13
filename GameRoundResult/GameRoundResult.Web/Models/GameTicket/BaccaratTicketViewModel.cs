using System;

namespace GameRoundResult.Web.Models
{
    public class BaccaratTicketViewModel : GameTicketViewModel
    {
        public BaccaratRoundResultViewModel RoundResult { get; set; }

        public BaccaratBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Banker + Bet.BankerPair + Bet.Player + Bet.PlayerPair + Bet.Tie + Bet.Big + Bet.Small;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class BaccaratBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Banker { get; set; }

        public decimal BankerPair { get; set; }

        public decimal Player { get; set; }

        public decimal PlayerPair { get; set; }

        public decimal Tie { get; set; }

        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal BetWin { get; set; }
    }
}