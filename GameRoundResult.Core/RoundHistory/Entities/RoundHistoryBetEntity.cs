using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.RoundHistory
{
    public class RoundHistoryBetEntity : BaseBetEntity
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public decimal TotalAmount { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }
}