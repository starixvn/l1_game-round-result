using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models.GameRoundResult;
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
            else if (RoundResult.SettlementResult.Seven)
            {
                return "glossary_7";
            }

            return string.Empty;
        }

        public string GetMultiplierValue()
        {
            return IsMultiplerValue ? $"{RoundResult.Multiplier.Value}x" : string.Empty;
        }

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

        public string DisplayMultiplierValue(string choice)
        {
            if (IsMultiplerValue && RoundResult.Multiplier.Choice.Equals(choice, StringComparison.OrdinalIgnoreCase))
            {
                return $"{RoundResult.Multiplier.Value}x";
            }
            return "-";
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
