using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Requests.RoundHistory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GameRoundResult.Web.Models.RoundHistory
{
    public class RoundHistoryViewModel
    {
        public RoundResultViewModel Round { get; set; }
        public IEnumerable<RoundHistoryBetViewModel> Bets { get; set; }
        public RoundHistoryRequest Request { get; set; }
        public int BaseCurrencyMultiplier { get; set; }
        public string BaseCurrency { get; set; }

        public string GetTolgeeNamespaces()
        {
            var baseNs = "GameRoundResultViewModel,RoundResultViewModel,GameType,";
            var types = Assembly.GetAssembly(typeof(TolgeeNamespace)).GetTypes().Where(type => type.IsSubclassOf(typeof(TolgeeNamespace)));
            var ns = string.Join(',', types.Select(type => type.Name));
            return baseNs + ns;
        }
    }

    public class RoundHistoryBetViewModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Time { get; set; }

        public decimal Betwin { get; set; }

        public string Currency { get; set; }

        public string OperatorId { get; set; }

        public string OperatorName { get; set; }

        public string PlayerId { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public decimal ConvertToBase(decimal value) => value * Rate;

        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);
    }
}