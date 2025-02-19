using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Configuration
{
    public class HostConfiguration
    {
        public Uri Domain { get; set; }

        public Dictionary<string, Uri> OperatorsDomain { get; set; }

        public Uri GetDomain(string operatorId)
        {
            if (string.IsNullOrEmpty(operatorId))
            {
                return Domain;
            }
            var operatorDomain = Domain;
            if (OperatorsDomain?.TryGetValue(operatorId, out operatorDomain) == true)
            {
                return operatorDomain;
            }
            return Domain;
        }
    }
}