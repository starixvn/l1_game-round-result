using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("lottery_phiens")]
    public class LotteryRound : GameRound
    {
        public LotteryResult Result { get; set; }

        public LotterySettlementResult SettlementResult { get; set; }
    }

    public class LotteryResult
    {
        public IEnumerable<string> Special { get; set; }
        public IEnumerable<string> First { get; set; }
        public IEnumerable<string> Second { get; set; }
        public IEnumerable<string> Third { get; set; }
        public IEnumerable<string> Fourth { get; set; }
        public IEnumerable<string> Fifth { get; set; }
        public IEnumerable<string> Sixth { get; set; }
        public IEnumerable<string> Seventh { get; set; }
    }

    public class LotterySettlementResult
    {
        [BsonElement("4Sets")]
        public IEnumerable<string> FourSets { get; set; }

        public string Special { get; set; }

        public string Head { get; set; }

        public string Tail { get; set; }

        public Dictionary<string, bool> Others { get; set; }

        [BsonElement("27Sets")]
        public IEnumerable<string> TwentySevenSets { get; set; }

        public LotteryOccurrences Occurrences { get; set; }
    }

    public class LotteryOccurrences
    {
        public Dictionary<string, byte> All { get; set; }
        public Dictionary<string, byte> Seventh { get; set; }
    }
}