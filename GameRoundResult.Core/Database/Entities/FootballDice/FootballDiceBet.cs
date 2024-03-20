using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballdice_bets")]
    public class FootballDiceBet : BaseBetEntity
    {
        public decimal Home { get; set; }

        public decimal Away { get; set; }

        public decimal Draw { get; set; }

        public decimal TotalAmount { get; set; }
    }
}