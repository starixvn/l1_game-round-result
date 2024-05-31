using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinToss
{
    [CollectionName("cointoss_rounds")]
    public class CoinTossRound : GameRound
    {
        public long DrawId { get; set; }
        public CoinTossResult Result { get; set; }

        public CoinTossSettlementResult SettlementResult { get; set; }
    }

    public class CoinTossResult
    {
        public bool Head { get; set; }

        public bool Tail { get; set; }
    }

    public class CoinTossSettlementResult
    {
        public bool Head { get; set; }

        public bool Tail { get; set; }
    }
}