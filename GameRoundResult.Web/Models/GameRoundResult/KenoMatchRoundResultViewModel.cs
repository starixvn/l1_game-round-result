using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class KenoMatchRoundResultViewModel : RoundResultViewModel
    {
        public KenoSoccerPeriodViewModel HalfTime { get; set; }

        public KenoSoccerPeriodViewModel FullTime { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GeResultContent(stringLocalizer),
                GetPeriodSettlementResultContent(stringLocalizer, HalfTime.SettlementResult),
                GetPeriodSettlementResultContent(stringLocalizer, FullTime.SettlementResult),
            };

            return result;
        }

        private string GeResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-result");
            var tbody = new TagBuilder("tbody");

            tbody.InnerHtml.AppendHtml(GetHomeTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetNumbers(HalfTime.Result.Blue));
            tbody.InnerHtml.AppendHtml(GetNumbers(FullTime.Result.Red));
            tbody.InnerHtml.AppendHtml(GetAwayTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetNumbers(HalfTime.Result.Blue));
            tbody.InnerHtml.AppendHtml(GetNumbers(FullTime.Result.Red));
            tbody.InnerHtml.AppendHtml(GetHalfTimeSummary(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFullTimeSummary(stringLocalizer));

            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private static string GetPeriodSettlementResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer,
            KenoMatchPeriodSettlementResultViewModel settlementResult)
        {
            var stringBuilder = new StringBuilder();
            if (settlementResult.Blue)
            {
                stringBuilder.AppendLine(stringLocalizer["Home"]);
            }
            else
            {
                if (settlementResult.Red)
                {
                    stringBuilder.AppendLine(stringLocalizer["Away"]);
                }
            }

            stringBuilder.AppendLine(settlementResult.Over ? stringLocalizer["Over"] : stringLocalizer["Under"]);
            stringBuilder.AppendLine(settlementResult.Even ? stringLocalizer["Even"] : stringLocalizer["Odd"]);

            return stringBuilder.ToString();
        }

        private TagBuilder GetHalfTimeSummary(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append($"{stringLocalizer["First Half"]} - {HalfTime.Total}");

            var blueFTSum = FullTime.Result.Blue.Sum();
            var redFTSum = FullTime.Result.Red.Sum();

            cell.InnerHtml.Append($" ({stringLocalizer["Team Blue"]} {blueFTSum}, {stringLocalizer["Team Red"]} {redFTSum})");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetFullTimeSummary(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append($"{stringLocalizer["Full Time"]} - {FullTime.Total}");

            var blueFTSum = FullTime.Result.Blue.Sum();
            var redFTSum = FullTime.Result.Red.Sum();

            cell.InnerHtml.Append($" ({stringLocalizer["Team Blue"]} {blueFTSum}, {stringLocalizer["Team Red"]} {redFTSum})");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private static TagBuilder GetNumbers(IEnumerable<int> numbers)
        {
            var row = new TagBuilder("tr");
            row.AddCssClass("bold");
            foreach (var number in numbers)
            {
                var cell = new TagBuilder("td");
                cell.InnerHtml.Append(number.ToString());
                row.InnerHtml.AppendHtml(cell);
            }

            return row;
        }

        private static TagBuilder GetHomeTitle(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append(stringLocalizer["Home"]);
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private static TagBuilder GetAwayTitle(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append(stringLocalizer["Away"]);
            row.InnerHtml.AppendHtml(cell);

            return row;
        }
    }

    public class KenoSoccerPeriodViewModel
    {
        public DateTime Time { get; set; }

        public int Total { get; set; }

        public KenoSoccerPeriodResultViewModel Result { get; set; }

        public KenoMatchPeriodSettlementResultViewModel SettlementResult { get; set; }
    }

    public class KenoSoccerPeriodResultViewModel
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