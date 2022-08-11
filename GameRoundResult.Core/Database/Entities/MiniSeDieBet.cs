using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("minisedie_cuocs")]
    public class MiniSeDieBet : BaseBetEntity
    {
        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        [BsonElement("red3")]
        public decimal ThreeRed { get; set; }

        [BsonElement("red4")]
        public decimal FourRed { get; set; }

        [BsonElement("white3")]
        public decimal ThreeWhite { get; set; }

        [BsonElement("white4")]
        public decimal FourWhite { get; set; }
    }

    [CollectionName("minisedie2_bets")]
    public class MiniSeDie2Bet : MiniSeDieBet
    {
    }

    [CollectionName("minisedie3_bets")]
    public class MiniSeDie3Bet : MiniSeDieBet
    {
    }

    [CollectionName("minisedie4_bets")]
    public class MiniSeDie4Bet : MiniSeDieBet
    {
    }
}