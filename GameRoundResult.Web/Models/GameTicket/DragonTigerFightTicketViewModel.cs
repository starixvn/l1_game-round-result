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

        public string GetBetLogWin(DragonTigerFightBetLogViewModel bet, string choice)
        {
            decimal betWin = 0;
            var amount = (decimal)bet.GetType().GetProperty(choice).GetValue(bet, null);
            if (RoundResult.SettlementResult.Tie && (choice == "Dragon" || choice == "Tiger"))
            {
                betWin += amount / 2;
            }

            if (RoundResult.IsWinningChoice(choice))
            {
                betWin += GetOdds(choice) * amount;
            }

            return betWin.Format();            
        }
    }

    public class DragonTigerFightBetLogViewModel : BetLogViewModel
    {
        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }

        public decimal BlackDragon { get; set; }

        public decimal RedDragon { get; set; }

        public decimal BlackTiger { get; set; }

        public decimal RedTiger { get; set; }

        public decimal BetWin { get; set; }
    }
}