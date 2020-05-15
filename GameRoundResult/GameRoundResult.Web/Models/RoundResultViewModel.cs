using System;

namespace GameRoundResult.Web.Models
{
    public abstract class RoundResultViewModel
    {
        public DateTime Time { get; set; }

        public long Round { get; set; }
    }
}