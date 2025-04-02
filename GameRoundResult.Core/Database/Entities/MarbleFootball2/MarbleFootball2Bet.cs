using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marblefootball2_bets")]
    public class MarbleFootball2Bet : RoundHistoryBetEntity
    {
        public decimal Home { get; set; }

        public decimal Away { get; set; }

        public decimal Draw { get; set; }

        public decimal Over { get; set; }

        public decimal Under { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal HomeLive { get; set; }

        public decimal AwayLive { get; set; }

        public decimal DrawLive { get; set; }

        public decimal OverLive { get; set; }

        public decimal UnderLive { get; set; }

        public decimal OddLive { get; set; }

        public decimal EvenLive { get; set; }
    }
}
