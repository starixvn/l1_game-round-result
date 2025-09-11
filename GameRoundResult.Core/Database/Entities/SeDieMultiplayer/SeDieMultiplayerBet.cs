using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.SeDieMultiplayer
{
    [CollectionName("sediemultiplayer_bets")]
    public class SeDieMultiplayerBet : RoundHistoryBetEntity
    {
        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        [BsonElement("red2")]
        public decimal TwoRed { get; set; }

        [BsonElement("red3")]
        public decimal ThreeRed { get; set; }

        [BsonElement("red4")]
        public decimal FourRed { get; set; }

        [BsonElement("white3")]
        public decimal ThreeWhite { get; set; }

        [BsonElement("white4")]
        public decimal FourWhite { get; set; }
    }
}
