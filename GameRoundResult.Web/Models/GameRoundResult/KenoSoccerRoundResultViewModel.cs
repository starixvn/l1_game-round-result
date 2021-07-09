using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class KenoSoccerRoundResultViewModel : RoundResultViewModel
    {
        public KenoSoccerPeriodViewModel HalfTime { get; set; }

        public KenoSoccerPeriodViewModel FullTime { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GeResultContent(stringLocalizer),
            };

            return result;
        }

        private string GeResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-result");
            var tbody = new TagBuilder("tbody");

            tbody.InnerHtml.AppendHtml(GetHomeTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetNumbers(HalfTime.Result.Home));
            tbody.InnerHtml.AppendHtml(GetNumbers(FullTime.Result.Home));
            tbody.InnerHtml.AppendHtml(GetAwayTitle(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetNumbers(HalfTime.Result.Away));
            tbody.InnerHtml.AppendHtml(GetNumbers(FullTime.Result.Away));
            tbody.InnerHtml.AppendHtml(GetHalfTimeSummary(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetPeriodSettlementResult(stringLocalizer, HalfTime.SettlementResult));
            tbody.InnerHtml.AppendHtml(GetFullTimeSummary(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetPeriodSettlementResult(stringLocalizer, FullTime.SettlementResult));

            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }
        private TagBuilder GetPeriodSettlementResult(IStringLocalizer<RoundResultViewModel> stringLocalizer,
            KenoSoccerPeriodSettlementResultViewModel settlementResult)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.AddCssClass("bold");
            cell.InnerHtml.Append(settlementResult.Home ? stringLocalizer["Home"] : stringLocalizer["Away"]);
            cell.InnerHtml.Append($", {(settlementResult.Over ? stringLocalizer["Over"] : stringLocalizer["Under"])}");
            cell.InnerHtml.Append($", {(settlementResult.Even ? stringLocalizer["Even"] : stringLocalizer["Odd"])}");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetHalfTimeSummary(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append($"{stringLocalizer["Half Time"]} - {HalfTime.Total}");

            var homeFTSum = FullTime.Result.Home.Sum();
            var awayFTSum = FullTime.Result.Away.Sum();

            cell.InnerHtml.Append($" ({stringLocalizer["Home"]} {homeFTSum}, {stringLocalizer["Away"]} {awayFTSum})");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetFullTimeSummary(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append($"{stringLocalizer["Full Time"]} - {FullTime.Total}");

            var homeFTSum = FullTime.Result.Home.Sum();
            var awayFTSum = FullTime.Result.Away.Sum();

            cell.InnerHtml.Append($" ({stringLocalizer["Home"]} {homeFTSum}, {stringLocalizer["Away"]} {awayFTSum})");
            row.InnerHtml.AppendHtml(cell);

            return row;
        }


        private TagBuilder GetNumbers(IEnumerable<int> numbers)
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

        private TagBuilder GetHomeTitle(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "10");
            cell.InnerHtml.Append(stringLocalizer["Home"]);
            row.InnerHtml.AppendHtml(cell);

            return row;
        }

        private TagBuilder GetAwayTitle(IStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        public KenoSoccerPeriodSettlementResultViewModel SettlementResult { get; set; }
    }

    public class KenoSoccerPeriodResultViewModel
    {
        public List<int> Home { get; set; }
        public List<int> Away { get; set; }
    }

    public class KenoSoccerPeriodSettlementResultViewModel
    {
        public bool Home { get; set; }
        public bool Away { get; set; }
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
    }
}