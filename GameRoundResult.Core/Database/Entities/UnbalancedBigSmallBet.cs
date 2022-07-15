using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class UnbalancedBigSmallBet : BaseBetEntity
    {
        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal TotalAmount { get; set; }
    }

    [CollectionName("unbalancedbigsmall1_bets")]
    public class UnbalancedBigSmall1Bet : UnbalancedBigSmallBet
    {
    }

    [CollectionName("unbalancedbigsmall2_bets")]
    public class UnbalancedBigSmall2Bet : UnbalancedBigSmallBet
    {
    }

    [CollectionName("unbalancedbigsmall3_bets")]
    public class UnbalancedBigSmall3Bet : UnbalancedBigSmallBet
    {
    }

    [CollectionName("unbalancedbigsmall4_bets")]
    public class UnbalancedBigSmall4Bet : UnbalancedBigSmallBet
    {
    }
}