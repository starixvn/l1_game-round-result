using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.KaraKrus
{
    [CollectionName("karakrus_betlogs")]
    public class KaraKrusBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
