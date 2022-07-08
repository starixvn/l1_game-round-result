using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("unbalancedbigsmall_rounds")]
    public class UnbalancedBigSmallRound : BigSmallRound
    {
    }

    [CollectionName("turbounbalancedbigsmall_rounds")]
    public class TurboUnbalancedBigSmallRound : UnbalancedBigSmallRound
    {
    }
}