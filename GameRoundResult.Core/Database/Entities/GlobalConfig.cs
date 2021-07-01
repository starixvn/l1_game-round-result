using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    public class GlobalConfig : Document
    {
        public string Type { get; set; }

        public Dictionary<string, IEnumerable<string>> Configs { get; set; }
    }
}