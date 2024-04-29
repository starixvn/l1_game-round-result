using GameRoundResult.Core._Share;
using GameRoundResult.Core.RoundHistory.Entities;

namespace GameRoundResult.Core.Database.Entities.CoinToss
{
    [CollectionName("cointoss_rounds")]
    public class CoinTossRound : RoundHistoryRoundEntity
    {
        public CoinTossResult Result { get; set; }

        public CoinTossSettlementResult SettlementResult { get; set; }
    }

    public class CoinTossResult
    {
        public int Coin { get; set; }
    }

    public class CoinTossSettlementResult
    {
        public bool Head { get; set; }

        public bool Tail { get; set; }        
    }       
}
