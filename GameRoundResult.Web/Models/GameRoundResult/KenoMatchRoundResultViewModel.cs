using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class KenoMatchRoundResultViewModel : RoundResultViewModel
    {
        public KenoMatchPeriodViewModel HalfTime { get; set; }

        public KenoMatchPeriodViewModel FullTime { get; set; }

        public bool Settled { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GeResultContent(stringLocalizer),
                GetPeriodSettlementResultContent(stringLocalizer, HalfTime.SettlementResult),
                GetPeriodSettlementResultContent(stringLocalizer, FullTime.SettlementResult),
            };

            return result;
        }

        private string GeResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-result");
            var tbody = new TagBuilder("tbody");

            tbody.InnerHtml.AppendHtml(GetTeamTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFirstHalfTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetPeriodResult(HalfTime.Result));
            tbody.InnerHtml.AppendHtml(GetHalfTimeSummary(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFullTimeTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetPeriodResult(FullTime.Result));
            tbody.InnerHtml.AppendHtml(GetFullTimeSummary(stringLocalizer));

            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private static TagBuilder GetPeriodResult(KenoMatchPeriodResultViewModel result)
        {
            var row = new TagBuilder("tr");
            var blueCell = new TagBuilder("td");
            blueCell.InnerHtml.AppendHtml(GetNumbers(result.Blue));
            row.InnerHtml.AppendHtml(blueCell);

            var redCell = new TagBuilder("td");
            redCell.InnerHtml.AppendHtml(GetNumbers(result.Red, false));
            row.InnerHtml.AppendHtml(redCell);

            return row;
        }

        private static TagBuilder GetFirstHalfTitle(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.AddCssClass("bold");
            cell.Attributes.Add("colspan", "2");
            cell.InnerHtml.Append(stringLocalizer["First Half"]);
            row.InnerHtml.AppendHtml(cell);
            return row;
        }

        private static TagBuilder GetFullTimeTitle(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.AddCssClass("bold");
            cell.Attributes.Add("colspan", "2");
            cell.InnerHtml.Append(stringLocalizer["Full Time"]);
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private static string GetPeriodSettlementResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
            KenoMatchPeriodSettlementResultViewModel settlementResult)
        {
            var div1 = new TagBuilder("div");
            var div2 = new TagBuilder("div");
            var div3 = new TagBuilder("div");

            if (settlementResult.Blue)
            {
                div1.InnerHtml.Append(stringLocalizer["Team Blue"]);
            }
            else
            {
                div1.InnerHtml.Append(settlementResult.Red ? stringLocalizer["Team Red"] : stringLocalizer["Tie"]);
            }

            div2.InnerHtml.Append(settlementResult.Over ? stringLocalizer["Over"] : stringLocalizer["Under"]);
            div3.InnerHtml.Append(settlementResult.Even ? stringLocalizer["Even"] : stringLocalizer["Odd"]);

            return $"{div1.GetHtmlString()}{div2.GetHtmlString()}{div3.GetHtmlString()}";
        }

        private TagBuilder GetHalfTimeSummary(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "2");

            var blueFTSum = HalfTime.Result.Blue.Sum();
            var redFTSum = HalfTime.Result.Red.Sum();

            cell.InnerHtml.Append($"{stringLocalizer["Team Blue"]} {blueFTSum}");

            cell.InnerHtml.Append($" - {stringLocalizer["Total"]} {HalfTime.Total} - {stringLocalizer["Team Red"]} {redFTSum}");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetFullTimeSummary(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "2");

            var blueFTSum = FullTime.Result.Blue.Sum() + HalfTime.Result.Blue.Sum();
            var redFTSum = FullTime.Result.Red.Sum() + HalfTime.Result.Red.Sum();

            cell.InnerHtml.Append($"{stringLocalizer["Team Blue"]} {blueFTSum}");

            cell.InnerHtml.Append($" - {stringLocalizer["Total"]} {FullTime.Total} - {stringLocalizer["Team Red"]} {redFTSum}");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private static TagBuilder GetNumbers(IEnumerable<int> numbers, bool isBlue = true)
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

        private static TagBuilder GetTeamTitle(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

    public class KenoMatchPeriodViewModel
    {
        public DateTime Time { get; set; }

        public int Total { get; set; }

        public KenoMatchPeriodResultViewModel Result { get; set; }

        public KenoMatchPeriodSettlementResultViewModel SettlementResult { get; set; }
    }

    public class KenoMatchPeriodResultViewModel
    {
        public List<int> Blue { get; set; }
        public List<int> Red { get; set; }
    }

    public class KenoMatchPeriodSettlementResultViewModel
    {
        public bool Blue { get; set; }
        public bool Red { get; set; }
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
    }
}