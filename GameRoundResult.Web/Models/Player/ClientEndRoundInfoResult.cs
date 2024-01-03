using System;
using GameRoundResult.Core.Database.Entities.Player;

namespace GameRoundResult.Web.Models.Player
{
    public class EndRoundInfoResult : SGResult
    {
        public decimal TotalAmount { get; set; }

        public decimal TotalWin { get; set; }

        public decimal ValidBetAmount { get; set; }

        public DateTimeOffset? EndTime { get; set; }
    }
}
