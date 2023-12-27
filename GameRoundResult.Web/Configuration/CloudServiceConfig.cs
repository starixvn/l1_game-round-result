using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Configuration
{
    public class CloudServiceConfig
    {
        public bool IsCloudService { get; set; }

        public string OnPremiseResultUrl { get; set; }

        public string CloudResultUrl { get; set; }

        public IEnumerable<int> CloudGameIds { get; set; }

        public bool ShouldCallOnPremiseService(int gameTypeId)
            => IsCloudService && (CloudGameIds == null || !CloudGameIds.Contains(gameTypeId));

        public bool ShouldCallCloudService(int gameTypeId)
            => !IsCloudService && CloudGameIds != null && CloudGameIds.Contains(gameTypeId);
    }
}