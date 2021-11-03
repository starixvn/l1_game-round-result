using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoMatchBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }

    [CollectionName("kenomatch1_cuocs")]
    public class KenoMatch1Bet : KenoMatchBet
    {
    }

    [CollectionName("kenomatch2_cuocs")]
    public class KenoMatch2Bet : KenoMatchBet
    {
    }
}