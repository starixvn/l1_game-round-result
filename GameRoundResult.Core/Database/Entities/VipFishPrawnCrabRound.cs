using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
 
    [CollectionName("vipfishprawncrab_phiens")]
    public class VipFishPrawnCrabRound : GameRound
    {
        public VipFishPrawnCrabRoundResult Result { get; set; }

        public VipFishPrawnCrabSettlementResult SettlementResult { get; set; }
    }

    public class VipFishPrawnCrabRoundResult
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }
    }

    public class VipFishPrawnCrabSettlementResult
    {
        public bool Stag { get; set; }

        public bool Gourd { get; set; }

        public bool Rooster { get; set; }

        public bool Fish { get; set; }

        public bool Crab { get; set; }

        public bool Prawn { get; set; }

        public bool AnyTriple { get; set; }
    }
}