using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Configuration
{
    public class CloudServiceConfig
    {
        public bool IsCloudService { get; set; }

        public string OnPremiseResultUrl { get; set; }

        public IEnumerable<int> CloudGameIds { get; set; } = new List<int>();

        public bool ShouldCallOnPremiseService(int gameTypeId)
            => IsCloudService && !CloudGameIds.Contains(gameTypeId);
    }
}