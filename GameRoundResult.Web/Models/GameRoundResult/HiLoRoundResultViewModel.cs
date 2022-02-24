using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class HiLoRoundResultViewModel : RoundResultViewModel
    {
        public DateTime? EndTime { get; set; }

        public int TotalTurns { get; set; }

        public decimal Amount { get; set; }

        public decimal Betwin { get; set; }

        public bool Paid { get; set; }

        public IEnumerable<CardViewModel> Result { get; set; }
    }
}