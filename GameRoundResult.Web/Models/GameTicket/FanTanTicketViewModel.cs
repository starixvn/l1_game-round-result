using System;

namespace GameRoundResult.Web.Models
{
    public class FanTanTicketViewModel : GameTicketViewModel
    {
        public FanTanRoundResultViewModel RoundResult { get; set; }

        public FanTanBetViewModel Bet { get; set; }

        public decimal WinLoss => Bet.Betwin - Bet.TotalAmount;
    }

    public class FanTanBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Odd { get; set; }
        public decimal Even { get; set; }

        public decimal Fan1 { get; set; }
        public decimal Fan2 { get; set; }
        public decimal Fan3 { get; set; }
        public decimal Fan4 { get; set; }

        public decimal Kwok12 { get; set; }
        public decimal Kwok23 { get; set; }
        public decimal Kwok34 { get; set; }
        public decimal Kwok41 { get; set; }

        public decimal Chun123 { get; set; }
        public decimal Chun124 { get; set; }
        public decimal Chun134 { get; set; }
        public decimal Chun234 { get; set; }

        public decimal Betwin { get; set; }

        public decimal TotalAmount { get; set; }
    }
}