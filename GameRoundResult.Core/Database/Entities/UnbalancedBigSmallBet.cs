using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("unbalancedbigsmall_bets")]
    public class UnbalancedBigSmallBet : BaseBetEntity
    {
        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal TotalAmount { get; set; }
    }

    [CollectionName("turbounbalancedbigsmall_bets")]
    public class TurboUnbalancedBigSmallBet : UnbalancedBigSmallBet
    {

    }
}