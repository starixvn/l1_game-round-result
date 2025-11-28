using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            return choice.ToLower() switch
            {
                "noMove" => RoundResult?.SettlementResult.NoMove ?? false,
                "move" => RoundResult?.SettlementResult.Move ?? false,
                "kick" => RoundResult?.SettlementResult.Kick ?? false,
                "noKick" => RoundResult?.SettlementResult.NoKick ?? false,
                "release" => RoundResult?.SettlementResult.Release ?? false,
                "noRelease" => RoundResult?.SettlementResult.NoRelease ?? false,
                "goStable" => RoundResult?.SettlementResult.GoStable ?? false,
                "noStable" => RoundResult?.SettlementResult.NoStable ?? false,
                "big" => RoundResult?.SettlementResult.Big ?? false,
                "small" => RoundResult?.SettlementResult.Small ?? false,
                "odd" => RoundResult?.SettlementResult.Odd ?? false,
                "even" => RoundResult?.SettlementResult.Even ?? false,
                _ => false
            };
        }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";


        public string GetMultiplierValue() => IsMultiplerValue ? $"{RoundResult.Multiplier.Value}x&nbsp;" : string.Empty;

        public string GetMultiplierChoice()
        {
            var choice = RoundResult?.Multiplier?.Choice?.ToLower();
            if (string.IsNullOrEmpty(choice))
                return string.Empty;

            return choice switch
            {
                "seven" => "glossary_7",
                _ => $"glossary_{choice}"
            };
        }

        public string DisplayMultiplierValue(string choice) =>
            IsWinningChoice(choice) && IsMultiplerValue && RoundResult.Multiplier.Choice.Equals(choice, StringComparison.OrdinalIgnoreCase)
            ? $"{RoundResult.Multiplier.Value}x" : "-";

        public string GetWinningText(IJsonStringLocalizer<LudoTicketViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("text");

            string content = RoundResult.Total == 7
                ? $"| {RoundResult.Total}"
                : $"| {RoundResult.Total}";

            span.InnerHtml.Append(content);

            return span.GetHtmlString();
        }

        public string GetWinningOptions(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return RoundResult.GetWinningTextResult(stringLocalizer);
        }

        public override decimal GetBetLogWin(BetLogViewModel betLog) =>
            IsWinningChoice(betLog.Choice)
            ? betLog.Amount * CalculateFinalOdds(betLog.Choice) : 0;

        private decimal CalculateFinalOdds(string choice)
        {
            if (!Odds.TryGetValue(choice, out var baseOdds)) return 1;

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
            return RoundResult.GetText(stringLocalizer, choice);
        }


    }

    public class LudoBetLogViewModel : BetLogViewModel
    {
        public override string ChoiceKey
        {
            get
            {
                var choice = Choice?.ToLower();
                return string.IsNullOrEmpty(choice) ? string.Empty : $"glossary_{choice}";
            }
        }
    }
}
