using System;
using System.Globalization;
using System.Text;
using GameRoundResult.Web.Configuration;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class GameTicketViewModel
    {
        public TimeSpan TimeZoneOffset { get; set; }

        public string TimeOffsetString => $"GMT{TimeZoneOffset.Hours:+#;-#}";

        public bool? FractionalOddsFormat { get; set; }
        public decimal TotalBet { get; set; }
        public decimal BetWin { get; set; }
        public decimal WinLoss => BetWin - TotalBet;
        public string WinLossRowClassName => WinLoss < 0 ? "text-red" : string.Empty;
    }

    public class BetLogViewModel
    {
        public DateTime Time { get; set; }
        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}