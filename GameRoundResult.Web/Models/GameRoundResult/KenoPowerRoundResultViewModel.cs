using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class KenoPowerRoundResultViewModel : RoundResultViewModel
    {
        public KenoPowerResultViewModel Result { get; set; }
        public KenoPowerSettlementResultViewModel SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GeResultContent(stringLocalizer),
                GetPlayerBankerSettlementResultContent(stringLocalizer),
                GetPlayerSettlementResultContent(stringLocalizer),
                GetBankerSettlementResultContent(stringLocalizer),
                GetTotalSettlementResultContent(stringLocalizer),
            };

            return result;
        }

        private string GetTotalSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(SettlementResult.Big ? stringLocalizer["Big"] : stringLocalizer["Small"]);
            stringBuilder.AppendLine(SettlementResult.Odd ? stringLocalizer["Odd"] : stringLocalizer["Even"]);

            if (SettlementResult.Red)
            {
                stringBuilder.AppendLine(stringLocalizer["Red"]);
            }
            if (SettlementResult.Orange)
            {
                stringBuilder.AppendLine(stringLocalizer[")"]);
            }
            if (SettlementResult.Yellow)
            {
                stringBuilder.AppendLine(stringLocalizer["Yellow"]);
            }
            if (SettlementResult.Green)
            {
                stringBuilder.AppendLine(stringLocalizer["Green"]);
            }
            if (SettlementResult.Blue)
            {
                stringBuilder.AppendLine(stringLocalizer["Blue"]);
            }
            if (SettlementResult.Indigo)
            {
                stringBuilder.AppendLine(stringLocalizer["Indigo"]);
            }
            if (SettlementResult.Violet)
            {
                stringBuilder.AppendLine(stringLocalizer["Violet"]);
            }

            return stringBuilder.ToString();
        }

        private string GeResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-result");
            var tbody = new TagBuilder("tbody");

            tbody.InnerHtml.AppendHtml(GetTeamTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetResultContent());
            tbody.InnerHtml.AppendHtml(GetSummaryContent(stringLocalizer));

            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private TagBuilder GetSummaryContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "2");

            var playerSum = Result.Player.Sum(x => x);
            var bankerSum = Result.Banker.Sum(x => x);

            cell.InnerHtml.Append($"{stringLocalizer["Player"]} {playerSum}");

            cell.InnerHtml.Append($" - {stringLocalizer["Total"]} {playerSum + bankerSum} - {stringLocalizer["Banker"]} {bankerSum}");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetResultContent()
        {
            var row = new TagBuilder("tr");
            var blueCell = new TagBuilder("td");
            blueCell.InnerHtml.AppendHtml(GetNumbers(Result.Player));
            row.InnerHtml.AppendHtml(blueCell);

            var redCell = new TagBuilder("td");
            redCell.InnerHtml.AppendHtml(GetNumbers(Result.Banker));
            row.InnerHtml.AppendHtml(redCell);

            return row;
        }

        private string GetPlayerBankerSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.Player)
            {
                return stringLocalizer["Player"];
            }

            if (SettlementResult.Banker)
            {
                return stringLocalizer["Banker"];
            }

            return stringLocalizer["Draw"];
        }

        private string GetPlayerSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.PlayerBig)
            {
                return stringLocalizer["Big"];
            }

            return stringLocalizer["Small"];
        }

        private string GetBankerSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.BankerBig)
            {
                return stringLocalizer["Big"];
            }

            return stringLocalizer["Small"];
        }

        private static TagBuilder GetNumbers(IEnumerable<byte> numbers, bool isBlue = true)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("number-list");

            foreach (var number in numbers)
            {
                var span = new TagBuilder("span");
                span.AddCssClass($"number {(isBlue ? "blue" : "red")}");
                span.InnerHtml.Append(number.ToString());
                div.InnerHtml.AppendHtml(span);
            }

            return div;
        }

        private static TagBuilder GetTeamTitle(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            row.AddCssClass("bold");
            var blueCell = new TagBuilder("td");
            blueCell.InnerHtml.Append(stringLocalizer["Player"]);
            row.InnerHtml.AppendHtml(blueCell);

            var redCell = new TagBuilder("td");
            redCell.InnerHtml.Append(stringLocalizer["Banker"]);
            row.InnerHtml.AppendHtml(redCell);

            return row;
        }
    }

    public class KenoPowerResultViewModel
    {
        public IEnumerable<byte> Player { get; set; }
        public IEnumerable<byte> Banker { get; set; }
    }

    public class KenoPowerSettlementResultViewModel
    {
        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Red { get; set; }
        public bool Orange { get; set; }
        public bool Yellow { get; set; }
        public bool Green { get; set; }
        public bool Blue { get; set; }
        public bool Indigo { get; set; }
        public bool Violet { get; set; }
        public bool PlayerBig { get; set; }
        public bool PlayerSmall { get; set; }
        public bool BankerBig { get; set; }
        public bool BankerSmall { get; set; }
    }
}