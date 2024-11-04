using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models.GameTicket
{
    [TolgeeNamespace("7Up7Down")]
    public class SevenUpDownTicketViewModel : GameTicketViewModel
    {
        public SevenUpDownRoundResultViewModel RoundResult { get; set; }

        public bool IsMultiplerValue => RoundResult?.Multiplier != null;

        public IEnumerable<SevenUpDownBetLogViewModel> BetLogs { get; set; }

        public bool ReachMaxWin { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            return choice.ToLower() switch
            {
                "up" => RoundResult?.SettlementResult.Up ?? false,
                "down" => RoundResult?.SettlementResult.Down ?? false,
                "seven" => RoundResult?.SettlementResult.Seven ?? false,
                _ => false
            };
        }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";

        public string WinningOption()
        {
            if (RoundResult.SettlementResult.Up)
            {
                return "glossary_up";
            }
            else if (RoundResult.SettlementResult.Down)
            {
                return "glossary_down";
            }
           
            return string.Empty;
        }

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

        public string GetWinningText(IJsonStringLocalizer<SevenUpDownTicketViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("text");

            string content = RoundResult.Total == 7
                ? $"| {RoundResult.Total}"
                : $"| {RoundResult.Total} - {stringLocalizer[WinningOption()]}";

            span.InnerHtml.Append(content);

            return span.GetHtmlString();
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
    }

    public class SevenUpDownBetLogViewModel : BetLogViewModel
    {
        public override string ChoiceKey
        {
            get
            {
                var choice = Choice?.ToLower();
                return choice switch
                {
                    "seven" => "glossary_7",
                    _ => string.IsNullOrEmpty(choice) ? string.Empty : $"glossary_{choice}"
                };
            }
        }
    }
}
