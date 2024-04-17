using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballdice_betlogs")]
    public class FootballDiceBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }

        public string Choice { get; set; }
    }
}