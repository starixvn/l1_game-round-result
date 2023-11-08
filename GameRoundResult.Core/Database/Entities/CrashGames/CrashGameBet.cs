using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class CrashGameBet : BaseBetEntity
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Amount { get; set; }
    }

    [CollectionName("spaceflight_bets")]
    public class SpaceFlightBet : CrashGameBet
    {
    }
}