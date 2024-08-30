using System.Collections.Generic;
using System.Text;
using GameRoundResult.Web.Models.GameRoundResult;

namespace GameRoundResult.Web.Models
{
    public class KaraKrusTicketViewModel : GameTicketViewModel
    {
        public KaraKrusRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<KaraKrusBetLogViewModel> BetLogs { get; set; }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";
        public override bool IsWinningChoice(string choice)
        {
            if (RoundResult?.SettlementResult == null)
            {
                return false;
            }

            return choice switch
            {
                "kara" => RoundResult.SettlementResult.Kara,
                "krus" => RoundResult.SettlementResult.Krus,
                "head1" => RoundResult.SettlementResult.OneHead,
                "head2" => RoundResult.SettlementResult.TwoHead,
                "head3" => RoundResult.SettlementResult.ThreeHead,
                "tail3" => RoundResult.SettlementResult.ThreeTail,
                _ => false
            };
        }

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) ? "bold bet-win-text" : string.Empty;
        }

        public string RenderChips(string choice)
        {
            int chipCount = choice switch
            {
                "head1" => 1,
                "head2" => 2,
                "head3" => 3,
                "tail3" => 3,
                _ => 0
            };

            var cssClass = choice.StartsWith("head") ? "dice-kara" : "dice-krus";
            var oppositeCssClass = choice.StartsWith("head") ? "dice-krus" : "dice-kara";

            int oppositeChipCount = 3 - chipCount;

            var sb = new StringBuilder();
            for (int i = 0; i < chipCount; i++)
            {
                sb.Append($"<i class='{cssClass}'></i>");
            }

            for (int i = 0; i < oppositeChipCount; i++)
            {
                sb.Append($"<i class='{oppositeCssClass}'></i>");
            }

            return sb.ToString();
        }
    }

    public class KaraKrusBetLogViewModel : BetLogViewModel
    {
        public override string ChoiceKey
        {
            get
            {
                return char.ToUpper(Choice[0]) + Choice.Substring(1);
            }
        }
    }
}
