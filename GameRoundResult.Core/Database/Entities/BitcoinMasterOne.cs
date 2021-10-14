using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("bitcoinmaster_bets")]
    public class BitcoinMasterOne : BaseBetEntity
    {
        public bool Win { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }
    }
}