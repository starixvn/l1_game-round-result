using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.RNGSoccer
{
    [CollectionName("rngsoccer_betlogs")]
    public class RNGSoccerBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
