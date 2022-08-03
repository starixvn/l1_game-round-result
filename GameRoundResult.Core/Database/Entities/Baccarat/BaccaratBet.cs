using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("baccarat_cuocs")]
    public class BaccaratBet : BaseBetEntity
    {
        public decimal Banker { get; set; }

        public decimal BankerPair { get; set; }

        public decimal Player { get; set; }

        public decimal PlayerPair { get; set; }

        public decimal Tie { get; set; }

        public decimal Big { get; set; }

        public decimal Small { get; set; }
    }

    [CollectionName("vipbaccarat_cuocs")]
    public class VipBaccaratBet : BaccaratBet
    {
    }

    [CollectionName("blockchainbaccarat_bets")]
    public class BlockchainBaccaratBet : BaccaratBet
    {
    }
}