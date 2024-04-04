using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballslot_betlogs")]
    public class FootballSlotBetLog : BaseBetLogEntity
    {
        public string Choice { get; set; }
        public IEnumerable<string> SubChoices { get; set; }
        public decimal Amount { get; set; }
    }
}