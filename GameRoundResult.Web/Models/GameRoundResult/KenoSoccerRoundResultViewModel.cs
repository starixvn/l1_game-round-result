using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class KenoSoccerRoundResultViewModel : RoundResultViewModel
    {
        public KenoSoccerPeriodViewModel HalfTime { get; set; }

        public KenoSoccerPeriodViewModel FullTime { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }

    public class KenoSoccerPeriodViewModel
    {
        public DateTime Time { get; set; }

        public int Total { get; set; }

        public KenoSoccerPeriodResultViewModel Result { get; set; }
    }

    public class KenoSoccerPeriodResultViewModel
    {
        public List<int> Home { get; set; }
        public List<int> Away { get; set; }
    }

    public class KenoSoccerPeriodSettlementResultViewModel
    {
        public bool Home { get; set; }
        public bool Away { get; set; }
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
    }
}