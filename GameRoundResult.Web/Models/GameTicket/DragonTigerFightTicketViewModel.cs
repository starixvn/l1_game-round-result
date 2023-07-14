using GameRoundResult.Web.Configuration;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class DragonTigerFightTicketViewModel : GameTicketViewModel
    {
        public DragonTigerFightRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<DragonTigerFightBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public List<string> BetChoices => new List<string> { "Dragon", "Tiger", "Tie", "BlackDragon", "RedDragon", "BlackTiger", "RedTiger" };

        public string GetRowBetClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold text-blue" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            var oddsChoice = char.ToLower(choice[0]) + choice.Substring(1);
            return Odds[oddsChoice];
        }

        public decimal  GetBetLogWin(DragonTigerFightBetLogViewModel bet)
        {
            decimal betWin = 0;
            if (RoundResult.SettlementResult.Tie && (bet.Choice == "dragon" || bet.Choice == "tiger"))
            {
                betWin += bet.Amount / 2;
            }

            if (RoundResult.IsWinningChoice(bet.ChoiceDisplay))
            {
                betWin += GetOdds(bet.Choice) * bet.Amount;
            }

            return betWin;            
        }
    }

    public class DragonTigerFightBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}