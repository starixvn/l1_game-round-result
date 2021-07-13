using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("minidragontiger_cuocs")]
    public class DragonTigerBet : BaseBetEntity
    {
        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }
    }
}
