using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("minidragontiger_phiens")]
    public class DragonTigerRound : GameRound
    {
        public DragonTigerResult Result { get; set; }
        public DragonTigerCard Dragon { get; set; }

        public DragonTigerCard Tiger { get; set; }
    }

    public class DragonTigerResult
    {
        public DragonTigerCard Dragon { get; set; }

        public DragonTigerCard Tiger { get; set; }
    }

    public class DragonTigerCard
    {
        [BsonElement("card")]
        public byte Number { get; set; }

        public byte Type { get; set; }
    }
}