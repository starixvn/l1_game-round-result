using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.SevenUpDown
{
    [CollectionName("sevenupdown_betlogs")]
    public class SevenUpDownBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
