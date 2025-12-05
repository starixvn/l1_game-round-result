using System.Collections.Generic;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SpinnerSoccerUltraLive")]
    public class Marbles158TicketViewModel : GameTicketViewModel
    {
        public Marbles158RoundResultViewModel RoundResult { get; set; }

        public IEnumerable<Marbles158BetLogViewModel> BetLogs { get; set; }

        public Dictionary<int, Dictionary<string, Marbles158BetOdds>> MarbleOdds { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            if (RoundResult?.SettlementResult == null)
            {
                return false;
            }

            return choice.ToLowerInvariant() switch
            {
                "home" => RoundResult.SettlementResult.Home,
                "away" => RoundResult.SettlementResult.Away,
                "draw" => RoundResult.SettlementResult.Draw,
                "over" => RoundResult.SettlementResult.Over,
                "under" => RoundResult.SettlementResult.Under,
                "odd" => RoundResult.SettlementResult.Odd,
                "even" => RoundResult.SettlementResult.Even,
                _ => false,
            };
        }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) ? "bold bet-win-text" : string.Empty;
        }

        public decimal GetOdds(string choice, int index)
        {
            var detailOdds = MarbleOdds[index];

            return detailOdds.ContainsKey(choice) ? detailOdds[choice].Price : 0;
        }

        public string DisplayMarbleOdds(string choice, int index)
        {
            return GetOdds(choice, index).FormatOddsWithZero(FractionalOddsFormat);
        }

        public string DisplayMarbleChoice(IJsonStringLocalizer<Marbles158TicketViewModel> stringLocalizer,
            string choice, int index, string liveScore)
        {
            var choiceTranslation = stringLocalizer.GetStringWithNamcespace($"glossary_{choice}", "SpinnerSoccerUltraLive");

            return choice.ToLowerInvariant() switch
            {
                "over" => $"{choiceTranslation} {MarbleOdds[index][choice].Point} [{liveScore}]",
                "under" => $"{choiceTranslation} {MarbleOdds[index][choice].Point} [{liveScore}]",
                _ => $"{choiceTranslation} [{liveScore}]",
            };
        }

        public decimal GetBetLogWin(Marbles158BetLogViewModel bet)
        {
            return IsWinningChoice(bet.Choice) ? GetOdds(bet.Choice, bet.Index) * bet.Amount : 0;
        }
    }

    public class Marbles158BetLogViewModel : BetLogViewModel
    {
        public int Index { get; set; }
        public string LiveScore { get; set; }
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);
        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}
