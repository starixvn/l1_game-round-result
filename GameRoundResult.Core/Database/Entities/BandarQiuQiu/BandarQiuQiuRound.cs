using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BandarQiuQiu
{
    [CollectionName("bandarqiuqiu_rounds")]
    public class BandarQiuQiuRound : GameRound
    {
        public BandarQiuQiuRoundResult Result { get; set; }

        public Dictionary<string, int> SettlementResult { get; set; }
    }   

    public class BandarQiuQiuRoundResult
    {
        public BandarQiuQiuResultItem Banker { get; set; }

        public BandarQiuQiuResultItem Spade { get; set; }

        public BandarQiuQiuResultItem Heart { get; set; }

        public BandarQiuQiuResultItem Club { get; set; }

        public BandarQiuQiuResultItem Diamond { get; set; }
    }

    public class BandarQiuQiuResultItem
    {
        public List<string> Dominoes { get; set; }

        public int HandRankingId { get; set; }

        public IEnumerable<int> PipsOfSet { get; set; }
    }
}
