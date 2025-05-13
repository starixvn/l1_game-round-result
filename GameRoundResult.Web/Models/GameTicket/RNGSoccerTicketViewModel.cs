using GameRoundResult.Web.Configuration;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("RNGSoccer")]
    public class RNGSoccerTicketViewModel : GameTicketViewModel
    {
        public RNGSoccerRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<RNGSoccerBetLogViewModel> BetLogs { get; set; }

        public RNGSoccerBetViewModel Bet { get; set; }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";


        public override string GetRowBetClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold text-blue" : string.Empty;
        }

        public string GetValueClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            var oddsChoice = char.ToLower(choice[0]) + choice.Substring(1);
            return Odds[oddsChoice];
        }

        public decimal GetBetLogWin(RNGSoccerBetLogViewModel bet)
        {
            decimal betWin = 0;

            if (RoundResult.IsWinningChoice(bet.ChoiceDisplay))
            {
                betWin += GetOdds(bet.Choice) * bet.Amount;
            }

            return betWin;
        }
    }

    public class RNGSoccerBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }

    public class RNGSoccerBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Home { get; set; }

        public decimal Draw { get; set; }

        public decimal Away { get; set; }

        public decimal BetWin { get; set; }
    }
}
