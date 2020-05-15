using System;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultViewModel
    {
        public byte GameTypeId { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public long RoundId { get; set; }
    }
}