using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("bitcoinmaster_bets")]
    public class BitcoinMasterOne : BaseBetEntity
    {
        public string Choice { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Refund { get; set; }
    }
}