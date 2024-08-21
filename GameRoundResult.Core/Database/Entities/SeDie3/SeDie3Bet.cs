using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sedie3_bets")]
    public class SeDie3Bet : RoundHistoryBetEntity
    {
        public decimal Red { get; set; }

        public decimal White { get; set; }

        [BsonElement("red1")]
        public decimal OneRed { get; set; }

        [BsonElement("red2")]
        public decimal TwoRed { get; set; }

        [BsonElement("red3")]
        public decimal ThreeRed { get; set; }

        [BsonElement("white3")]
        public decimal ThreeWhite { get; set; }
    }
}
