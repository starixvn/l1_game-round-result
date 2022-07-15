using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class UnbalancedBigSmallRound : BigSmallRound
    {
    }

    [CollectionName("unbalancedbigsmall1_rounds")]
    public class UnbalancedBigSmall1Round : UnbalancedBigSmallRound
    {
    }

    [CollectionName("unbalancedbigsmall2_rounds")]
    public class UnbalancedBigSmall2Round : UnbalancedBigSmallRound
    {
    }

    [CollectionName("unbalancedbigsmall3_rounds")]
    public class UnbalancedBigSmall3Round : UnbalancedBigSmallRound
    {
    }

    [CollectionName("unbalancedbigsmall4_rounds")]
    public class UnbalancedBigSmall4Round : UnbalancedBigSmallRound
    {
    }
}