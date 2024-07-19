using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Requests.RoundHistory;

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
            var baseNs = "GameRoundResultViewModel,RoundResultViewModel,GameType,Bac81,";
            var types = Assembly.GetAssembly(typeof(TolgeeNamespace)).GetTypes().Where(type => type.IsSubclassOf(typeof(TolgeeNamespace)));
            var ns = string.Join(',', types.Select(type => type.Name));
            return baseNs + ns;
        }
        public string AdditionalViewName { get; set; }

        public decimal ConvertToBase(decimal value, decimal rate)
        {
            return value * rate / BaseCurrencyMultiplier;
        }

        public string DisplayAmount(decimal value, decimal rate)
        {
            if (Request.ConvertToUSD)
            {
                return ConvertToBase(value, rate).Format2Decimals();
            }

            return value.Format2Decimals();
        }

        public string DisplayTotalBet => Bets.Sum(x => ConvertToBase(x.TotalAmount, x.Rate)).Format2Decimals();
        public string DisplayTotalBetwin => Bets.Sum(x => ConvertToBase(x.Betwin, x.Rate)).Format2Decimals();
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

        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);
    }
}