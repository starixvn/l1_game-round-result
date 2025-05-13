using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.RNGSoccer
{
    [CollectionName("rngsoccer_rounds")]
    public class RNGSoccerRound : GameRound
    {
        public RNGSoccerResultEntity Result { get; set; }

        public RNGSoccerSettlementResultEntity SettlementResult { get; set; }

        public RNGSoccerMatchEntity Match { get; set; }
    }

    public class RNGSoccerResultEntity
    {
        public RNGSoccerCard Home { get; set; }

        public RNGSoccerCard Away { get; set; }
    }

    public class RNGSoccerMatchEntity
    {
        public string Home { get; set; }

        public string Away { get; set; }
    }

    public class RNGSoccerSettlementResultEntity
    {
        public bool Home { get; set; }

        public bool Away { get; set; }

        public bool Draw { get; set; }
    }

    public class RNGSoccerCard
    {
        public byte Rank { get; set; }

        public byte Suit { get; set; }
    }
}
