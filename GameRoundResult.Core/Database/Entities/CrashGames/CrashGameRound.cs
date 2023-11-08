using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class CrashGameRound : GameRound
    {
        public decimal Result { get; set; }
    }

    [CollectionName("spaceflight_rounds")]
    public class SpaceFlightRound : GameRound 
    { 
    }
}