using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoPowerOne : BaseBetEntity
    {
        public decimal Blue { get; set; }
        public decimal Red { get; set; }
        public decimal Big { get; set; }
        public decimal Small { get; set; }
        public decimal Odd { get; set; }
        public decimal Even { get; set; }
        public decimal BlueBig { get; set; }
        public decimal BlueSmall { get; set; }
        public decimal RedBig { get; set; }
        public decimal RedSmall { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal Refund { get; set; }
    }

    [CollectionName("kenopower1_ones")]
    public class KenoPower1One : KenoPowerOne
    {
    }

    [CollectionName("kenopower2_ones")]
    public class KenoPower2One : KenoPowerOne
    {
    }
}