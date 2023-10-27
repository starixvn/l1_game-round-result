using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class BandarQiuQiuTicketViewModel : GameTicketViewModel
    {
        public BandarQiuQiuRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BandarQiuQiuBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public const string Tie = "tie";

        public readonly Dictionary<int, string> HandRankingMapper = new Dictionary<int, string>() { { 0, "ordinaryCard" }, { 1, "qiuQiu" }, { 2, "big" }, { 3, "small" }, { 4, "twin" }, { 5, "sixDevil" } };

        public string GetRowBetClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold text-blue" : string.Empty;
        }
       
        public string GetWinningOddName(string choice)
        {
            var isWin = this.RoundResult.SettlementResult[choice.ToLower()];
            if (isWin == 0)
            {
                return string.Empty;
            }
            else if (isWin == 1) {
                return this.GetHandRanking(choice);
            }
            else
            {
                return Tie;
            }
        }

        private string GetHandRanking(string choice)
        {
            var displayChoice = char.ToUpper(choice[0]) + choice.Substring(1).Trim();
            BandarQiuQiuResultItemViewModel item = (BandarQiuQiuResultItemViewModel)this.RoundResult.GetType().GetProperty(displayChoice).GetValue(this.RoundResult, null);
            return this.HandRankingMapper[(int)item.HandRankingId];
        }

        public decimal GetOdds(string choice)
        {
            var winningOddsName = GetWinningOddName(choice);
            if (string.IsNullOrEmpty(winningOddsName))
            {
                return 0;
            }
            else if(winningOddsName == Tie)
            {
                return 1;
            }
            else
            {
                return Odds[winningOddsName];
            }
        }

        public decimal  GetBetLogWin(BandarQiuQiuBetLogViewModel bet)
        {
            var isWin = this.RoundResult.SettlementResult[bet.Choice.ToLower()];
            return isWin > 0 ? GetOdds(bet.Choice) * bet.Amount : 0;            
        }
    }

    public class BandarQiuQiuBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}