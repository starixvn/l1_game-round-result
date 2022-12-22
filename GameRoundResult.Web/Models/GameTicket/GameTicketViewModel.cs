using System;
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

        public string RenderEmptyRow(IStringLocalizer localizer, int colspan)
        {
            return $"<tr><td colspan=\"{colspan}\" class=\"text-center\">{localizer["NoDataAvailable"]}</td></tr>";
        }

        public string RenderTotalBetRow(IStringLocalizer localizer, int colspan)
        {
            return $"<tr>" +
                $"<td colspan=\"{colspan}\" class=\"text-right bold\">{localizer["Total"]}</td>" +
                $"<td>{TotalBet.Format()}</td><td>{BetWin.Format()}</td></tr>";
        }

        public string RenderWinLossRow(IStringLocalizer localizer, int colspan)
        {
            var className = WinLoss < 0 ? "text-red bold" : string.Empty;
            return $"<tr>" +
                $"<td colspan=\"{colspan}\" class=\"text-right bold\">{localizer["WinLoss"]}</td>" +
                $"<td colspan=\"2\" class=\"{className}\">{WinLoss.Format()}</td></tr>";
        }
    }

    public class BetLogViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}