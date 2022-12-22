using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GameRoundResult.Web.Configuration;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class Win3CardsTicketViewModel : GameTicketViewModel
    {
        public Win3CardsRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<Win3CardsBetLogViewModel> BetLogs { get; set; }
        public Dictionary<string, decimal> Odds { get; set; }

        public string RenderResult(IStringLocalizer<GameTicketViewModel> ticketLocalizer, IStringLocalizer<RoundResultViewModel> roundlocalizer)
        {
            if (RoundResult != null)
            {
                var result = new StringBuilder("<tr>");
                result.AppendLine($"<td>{RoundResult.Time.ToString(ViewFormat.RoundDateFormat)}" +
                    $"<br />{RoundResult.Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture)}</td>");
                result.AppendLine($"<td>{RoundResult.RoundId}</td>");
                result.AppendLine($"<td>{RoundResult.GetResultContent(roundlocalizer)}</td>");

                result.AppendLine("</tr>");
                return result.ToString();
            }
            else
            {
                const int colspan = 3;
                return RenderEmptyRow(ticketLocalizer, colspan);
            }
        }

        public string RenderBets(IStringLocalizer<GameTicketViewModel> ticketLocalizer, IStringLocalizer<RoundResultViewModel> roundlocalizer)
        {
            if (BetLogs.Any() && RoundResult != null)
            {
                const int colspan = 3;
                var result = new StringBuilder();
                foreach (var bet in BetLogs)
                {
                    result.AppendLine(RenderBet(roundlocalizer, bet));
                }
                result.AppendLine(RenderTotalBetRow(ticketLocalizer, colspan));
                result.AppendLine(RenderWinLossRow(ticketLocalizer, colspan));
                return result.ToString();
            }
            else
            {
                const int colspan = 5;
                return RenderEmptyRow(ticketLocalizer, colspan);
            }
        }

        private string RenderBet(IStringLocalizer<RoundResultViewModel> localizer, Win3CardsBetLogViewModel bet)
        {
            var win = RoundResult.IsWinningChoice(bet.ChoiceDisplay) ? (Odds[bet.Choice] * bet.Amount).Format() : "0";
            var result = new StringBuilder("<tr>");
            result.AppendLine($"<td>{bet.Time.ToString(ViewFormat.RoundDateFormat)}<br />{bet.Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture)}</td>");
            result.AppendLine($"<td>{localizer[bet.ChoiceDisplay == "Dragon" ? "DragonWin3Cards" : bet.ChoiceDisplay]}</td>");
            result.AppendLine($"<td>{Odds[bet.Choice].Format()}</td>");
            result.AppendLine($"<td>{bet.Amount.Format()}</td>");
            result.AppendLine($"<td>{win}</td>");
            result.AppendLine("</tr>");
            return result.ToString();
        }
    }

    public class Win3CardsBetLogViewModel : BetLogViewModel
    {
        public string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);
    }
}