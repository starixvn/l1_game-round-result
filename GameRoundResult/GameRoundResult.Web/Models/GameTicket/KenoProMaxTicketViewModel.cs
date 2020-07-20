using System;

namespace GameRoundResult.Web.Models
{
    public class KenoProMaxTicketViewModel : GameTicketViewModel
    {
        public KenoRoundResultViewModel RoundResult { get; set; }

        public KenoProMaxBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Odd + Bet.Even + Bet.Big + Bet.Small
            + Bet.Gold + Bet.Wood + Bet.Water + Bet.Fire + Bet.Earth;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class KenoProMaxBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal Gold { get; set; }

        public decimal Earth { get; set; }

        public decimal Fire { get; set; }

        public decimal Water { get; set; }

        public decimal Wood { get; set; }

        public decimal BetWin { get; set; }
    }
}