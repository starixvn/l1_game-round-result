using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public virtual IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, bool convertToUSD = false, int baseCurrencyMultiplier = 1)
        {
            return new List<string>();            
        }

        public virtual string GetRowBetClass(string choice)
        {
            return string.Empty;
        }

        public virtual decimal GetBetLogWin(BetLogViewModel bet)
        {
            return 0;
        }

        protected virtual string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            return string.Empty;
        }

        protected virtual decimal GetOdds(string choice)
        {
            return 0;
        }

        protected virtual string BuildRow(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, BetLogViewModel bet, bool convertToUSD, int baseCurrencyMultiplier)
        {
            var rowBuilder = new TagBuilder("tr");
            rowBuilder.AddCssClass(GetRowBetClass(bet.DisplayedChoice));

            AddColumn(rowBuilder, $"{bet.DateDisplay} <br/>  {bet.TimeDisplay}");
            AddColumn(rowBuilder, $"{GetChoice(stringLocalizer, bet.Choice)}");
            AddColumn(rowBuilder, $"{GetOdds(bet.Choice)}");
            AddColumn(rowBuilder, $"{(convertToUSD ? bet.ConvertToBase(bet.Amount, baseCurrencyMultiplier).Format() : bet.Amount.Format())}");
            AddColumn(rowBuilder, $"{(convertToUSD ? bet.ConvertToBase(GetBetLogWin(bet), baseCurrencyMultiplier).Format() : GetBetLogWin(bet).Format()) }");

            return rowBuilder.GetHtmlString();
        }

        protected virtual void AddColumn(TagBuilder rowBuilder, string content)
        {
            var col = new TagBuilder("td");
            col.InnerHtml.AppendHtml(content);
            rowBuilder.InnerHtml.AppendHtml(col);
        }
    }

    public class BetLogViewModel
    {
        public DateTime Time { get; set; }
        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public string DisplayAmount => Amount.Format();

        public decimal ConvertToBase(decimal amount, int baseCurrencyMultiplier)
        {
            var result = amount * Rate / baseCurrencyMultiplier;

            return result;
        }

        public virtual string DisplayedChoice => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public virtual string ChoiceKey => "glossary_" + Choice;
    }

    public class TranslationBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}