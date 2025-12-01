using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GameRoundResult.Web.Models.GameTicket
{
    [TolgeeNamespace("VNLudo")]
    public class LudoTicketViewModel : GameTicketViewModel
    {
        public LudoRoundResultViewModel RoundResult { get; set; }

        public bool IsMultiplerValue => RoundResult?.Multiplier != null;

        public IEnumerable<LudoBetLogViewModel> BetLogs { get; set; }

        public bool ReachMaxWin { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            if (string.IsNullOrWhiteSpace(choice))
            {
                return false;
            }

            var normalizedChoice = char.ToUpperInvariant(choice[0]) + choice.Substring(1);
            
            var property = typeof(LudoSettlementResultEntity).GetProperty(
                normalizedChoice,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property?.PropertyType == typeof(bool))
            {
                var value = property.GetValue(RoundResult.SettlementResult);
                return value is bool boolValue && boolValue;
            }

            return false;
        }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";


        public string GetMultiplierValue() => IsMultiplerValue ? $"{RoundResult.Multiplier.Value}x&nbsp;" : string.Empty;

        public string GetMultiplierChoice()
        {
            var choice = RoundResult?.Multiplier?.Choice?.ToLowerInvariant();
            if (string.IsNullOrEmpty(choice))
            {
                return string.Empty;
            }

            return $"glossary_{choice}";
        }

        public string DisplayMultiplierValue(string choice) =>
            IsWinningChoice(choice) && IsMultiplerValue && RoundResult.Multiplier.Choice.Equals(choice, StringComparison.OrdinalIgnoreCase)
            ? $"{RoundResult.Multiplier.Value}x" : "-";

        public string GetWinningText(IJsonStringLocalizer<LudoTicketViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("text");

            string content = $"| {RoundResult.Total}";

            span.InnerHtml.Append(content);

            return span.GetHtmlString();
        }

        public string GetWinningOptions(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return RoundResult.GetWinningTextResult(stringLocalizer);
        }

        public decimal GetOdds(string choice)
        {
            var oddsChoice = char.ToLower(choice[0]) + choice.Substring(1);
            return Odds[oddsChoice];
        }

        public override decimal GetBetLogWin(BetLogViewModel betLog) =>
            IsWinningChoice(betLog.Choice)
            ? betLog.Amount * CalculateFinalOdds(betLog.Choice) : 0;

        private decimal CalculateFinalOdds(string choice)
        {
            if (!Odds.TryGetValue(choice, out var baseOdds)) 
            {
                return 1;
            }

            return IsMultiplerValue && RoundResult.Multiplier.Choice.Equals(choice, StringComparison.OrdinalIgnoreCase)
                ? (baseOdds - 1) * RoundResult.Multiplier.Value + 1
                : baseOdds;
        }

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs)
            {
                result.Add(BuildRow(stringLocalizer, bet));
            }

            return result;
        }

        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            return RoundResult.GetText(stringLocalizer, TransformChoice(choice));
        }

        public static string TransformChoice(string str)
        {
            var choice = str;
            if (string.IsNullOrEmpty(choice))
            {
                return string.Empty;
            }
            string result = Regex.Replace(choice, "(?<!^)([A-Z])", "_$1").ToLowerInvariant();

            return $"glossary_{result}";
        }
    }

    public class LudoBetLogViewModel : BetLogViewModel
    {
        public override string ChoiceKey
        {
            get
            {
               return LudoTicketViewModel.TransformChoice(Choice);
            }
        }
    }
}
