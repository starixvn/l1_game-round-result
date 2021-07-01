using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class VipSeDieWarRound : GameRound
    {
        public VipSeDieWarRoundResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class VipSeDieWarHandResult
    {
        [BsonElement("red1")]
        public bool FirstChip { get; set; }

        [BsonElement("red2")]
        public bool SecondChip { get; set; }

        [BsonElement("red3")]
        public bool ThirdChip { get; set; }

        [BsonElement("red4")]
        public bool FourthChip { get; set; }
    }

    public class VipSeDieWarRoundResult
    {
        public VipSeDieWarHandResult Player { get; set; }

        public VipSeDieWarHandResult Banker { get; set; }
    }
}