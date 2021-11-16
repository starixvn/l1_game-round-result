using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("bitcoinmaster_betlogs")]
    public class BitcoinMasterBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }

        public decimal Betwin { get; set; }
    }
}