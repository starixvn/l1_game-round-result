using System;
using System.Globalization;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    public class GameTicketViewModel
    {
        public int GameId { get; set; }
        public GameConfigsType GameType { get; set; }
        public TimeSpan TimeZoneOffset { get; set; }

        public string TimeOffsetString => $"GMT{TimeZoneOffset.Hours:+#;-#}";    

        public bool? FractionalOddsFormat { get; set; }

        public string StaticResourceUrl { get; set; }
        public decimal TotalBet { get; set; }
        public decimal BetWin { get; set; }
        public decimal WinLoss => BetWin - TotalBet;
        public string DisplayWinLoss => WinLoss.Format();
        public string DisplayTotalBet => TotalBet.Format();
        public string DisplayBetWin => BetWin.Format();
        public string WinLossRowClassName => WinLoss < 0 ? "text-red" : string.Empty;
        public bool EnableTolgee { get; set; }
    }

    public class BetLogViewModel
    {
        public DateTime Time { get; set; }
        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public string DisplayAmount => Amount.Format();
    }

    public class TranslationBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}