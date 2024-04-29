using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.CoinToss
{
    [CollectionName("cointoss_bets")]
    public class CoinTossBet : RoundHistoryBetEntity
    {
        public decimal Head { get; set; }

        public decimal Tail { get; set; }        
        
        public decimal TotalBet => Head + Tail;
    }
}
