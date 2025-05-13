using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.RNGSoccer
{
    [CollectionName("rngsoccer_bets")]
    public class RNGSoccerBet : RoundHistoryBetEntity
    {
        public decimal Home { get; set; }

        public decimal Away { get; set; }

        public decimal Draw { get; set; }

        public decimal Sum => Home + Away + Draw;
    }
}
