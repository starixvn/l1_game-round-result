using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class FootballDiceTicketViewModel : GameTicketViewModel
    {
        public FootballDiceRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<FootballDiceBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public string GetRowBetClass(string choice)
        {
            return RoundResult.SettlementResult[choice.ToLower()] ? "bold text-blue" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            if (choice == FootballDiceOdds.Draw)
            {
                if (RoundResult.SettlementResult[FootballDiceOdds.Draw])
                {
                    return RoundResult.SettlementResult[FootballDiceOdds.Draw12] ? Odds[FootballDiceOdds.Draw12] : Odds[FootballDiceOdds.Draw];
                }

                return 0;
            }

            return Odds[choice];
        }

        public decimal GetBetLogWin(FootballDiceBetLogViewModel bet)
        {
            var isWin = RoundResult.SettlementResult[bet.Choice.ToLower()];

            if(isWin)
            {
                return  GetOdds(bet.Choice) * bet.Amount;
            }

            return RoundResult.SettlementResult[FootballDiceOdds.Draw] ? bet.Amount : 0;
        }
    }

    public class FootballDiceBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}