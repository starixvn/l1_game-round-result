using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class GameRound : Document
    {
        [BsonElement("id")]
        public long RoundId { get; set; }

        public long ExchangeRateId { get; set; }
    }
}