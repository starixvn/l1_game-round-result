using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.FootballCoin
{
    [CollectionName("footballcointoss_bets")]
    public class FootballCoinTossBet : RoundHistoryBetEntity
    {
        public decimal Head { get; set; }

        public decimal Tail { get; set; }        
        
        public decimal TotalBet => Head + Tail;
    }
}
