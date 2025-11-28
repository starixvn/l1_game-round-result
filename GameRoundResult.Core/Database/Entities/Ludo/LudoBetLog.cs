using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.Ludo
{
    [CollectionName("ludo_betlogs")]
    public class LudoBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
