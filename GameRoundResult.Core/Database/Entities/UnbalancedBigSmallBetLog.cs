using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("unbalancedbigsmall_betlogs")]
    public class UnbalancedBigSmallBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }

        public string Choice { get; set; }
    }

    [CollectionName("turbounbalancedbigsmall_betlogs")]
    public class TurboUnbalancedBigSmallBetLog : UnbalancedBigSmallBetLog
    {

    }
}