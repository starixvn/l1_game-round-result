using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("partner_configs")]
    public class PartnerConfig : Document
    {
        public string PartnerId { get; set; }

        public string Type { get; set; }

        public Dictionary<string, IEnumerable<string>> Value { get; set; }
    }
}