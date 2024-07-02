using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.FootballCoinToss
{
    [CollectionName("footballcointoss_bets")]
    public class FootballCoinTossBet : RoundHistoryBetEntity
    {
        public decimal Home { get; set; }

        public decimal Away { get; set; }        
        
        public decimal TotalBet => Home + Away;
    }
}
