using GameRoundResult.Core._Share;
using GameRoundResult.Core.RoundHistory.Entities;

namespace GameRoundResult.Core.Database.Entities.FootballCoinToss
{
    [CollectionName("footballcointoss_rounds")]
    public class FootballCoinTossRound : RoundHistoryRoundEntity
    {
        public FootballCoinTossResult Result { get; set; }

        public FootballCoinTossSettlementResult SettlementResult { get; set; }
    }

    public class FootballCoinTossResult
    {
        public bool Head { get; set; }

        public bool Tail { get; set; }
    }

    public class FootballCoinTossSettlementResult
    {
        public bool Head { get; set; }

        public bool Tail { get; set; }        
    }       
}
