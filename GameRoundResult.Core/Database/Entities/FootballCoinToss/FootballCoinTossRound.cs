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
        public bool Home { get; set; }

        public bool Away { get; set; }
    }

    public class FootballCoinTossSettlementResult
    {
        public bool Home { get; set; }

        public bool Away { get; set; }        
    }       
}
