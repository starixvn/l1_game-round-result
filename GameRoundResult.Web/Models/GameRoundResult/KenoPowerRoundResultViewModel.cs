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
                GetBlueRedSettlementResultContent(stringLocalizer),
                GetTotalSettlementResultContent(stringLocalizer),
                GetBlueSettlementResultContent(stringLocalizer),
                GetRedSettlementResultContent(stringLocalizer),
            };

            return result;
        }

        private string GetTotalSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var div1 = new TagBuilder("div");
            var div2 = new TagBuilder("div");

            div1.InnerHtml.Append(SettlementResult.Big ? stringLocalizer["Big"] : stringLocalizer["Small"]);
            div2.InnerHtml.Append(SettlementResult.Odd ? stringLocalizer["Odd"] : stringLocalizer["Even"]);

            return $"{div1.GetHtmlString()}{div2.GetHtmlString()}";
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

            var BlueSum = Result.Blue.Sum(x => x);
            var RedSum = Result.Red.Sum(x => x);

            cell.InnerHtml.Append($"{stringLocalizer["Team Blue"]} {BlueSum}");

            cell.InnerHtml.Append($" - {stringLocalizer["Total"]} {BlueSum + RedSum} - {stringLocalizer["Team Red"]} {RedSum}");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetResultContent()
        {
            var row = new TagBuilder("tr");
            var blueCell = new TagBuilder("td");
            blueCell.InnerHtml.AppendHtml(GetNumbers(Result.Blue));
            row.InnerHtml.AppendHtml(blueCell);

            var redCell = new TagBuilder("td");
            redCell.InnerHtml.AppendHtml(GetNumbers(Result.Red));
            row.InnerHtml.AppendHtml(redCell);

            return row;
        }

        private string GetBlueRedSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.Blue)
            {
                return stringLocalizer["Team Blue"];
            }
            else
            {
                return SettlementResult.Red ? stringLocalizer["Team Red"] : stringLocalizer["Tie"];
            }

        }

        private string GetBlueSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.BlueBig)
            {
                return stringLocalizer["Big"];
            }

            return stringLocalizer["Small"];
        }

        private string GetRedSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (SettlementResult.RedBig)
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
            blueCell.InnerHtml.Append(stringLocalizer["Team Blue"]);
            row.InnerHtml.AppendHtml(blueCell);

            var redCell = new TagBuilder("td");
            redCell.InnerHtml.Append(stringLocalizer["Team Red"]);
            row.InnerHtml.AppendHtml(redCell);

            return row;
        }
    }

    public class KenoPowerResultViewModel
    {
        public IEnumerable<byte> Blue { get; set; }
        public IEnumerable<byte> Red { get; set; }
    }

    public class KenoPowerSettlementResultViewModel
    {
        public bool Blue { get; set; }
        public bool Red { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool BlueBig { get; set; }
        public bool BlueSmall { get; set; }
        public bool RedBig { get; set; }
        public bool RedSmall { get; set; }
    }
}