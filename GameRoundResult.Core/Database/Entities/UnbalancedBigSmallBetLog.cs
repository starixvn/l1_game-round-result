using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class UnbalancedBigSmallBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }

        public string Choice { get; set; }
    }

    [CollectionName("unbalancedbigsmall1_betlogs")]
    public class UnbalancedBigSmall1BetLog : UnbalancedBigSmallBetLog
    {
    }

    [CollectionName("unbalancedbigsmall2_betlogs")]
    public class UnbalancedBigSmall2BetLog : UnbalancedBigSmallBetLog
    {
    }

    [CollectionName("unbalancedbigsmall3_betlogs")]
    public class UnbalancedBigSmall3BetLog : UnbalancedBigSmallBetLog
    {
    }

    [CollectionName("unbalancedbigsmall4_betlogs")]
    public class UnbalancedBigSmall4BetLog : UnbalancedBigSmallBetLog
    {
    }
}