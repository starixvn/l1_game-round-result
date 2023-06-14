using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class LotteryRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<string> Special { get; set; }
        public IEnumerable<string> First { get; set; }
        public IEnumerable<string> Second { get; set; }
        public IEnumerable<string> Third { get; set; }
        public IEnumerable<string> Fourth { get; set; }
        public IEnumerable<string> Fifth { get; set; }
        public IEnumerable<string> Sixth { get; set; }
        public IEnumerable<string> Seventh { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GeResultContent(stringLocalizer),
            };

            return result;
        }

        private string GeResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-result bold");
            var tbody = new TagBuilder("tbody");

            tbody.InnerHtml.AppendHtml(GetSpecialPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFirstPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetSecondPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetThirdPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFourthPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetFifthPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetSixthPrizeHtml(stringLocalizer));
            tbody.InnerHtml.AppendHtml(GetSeventhPrizeHtml(stringLocalizer));

            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private TagBuilder GetSpecialPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["Special"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            var resultCell = new TagBuilder("td");
            resultCell.AddCssClass("text-red");
            resultCell.Attributes.Add("colspan", "12");
            resultCell.InnerHtml.Append(Special.FirstOrDefault());
            row.InnerHtml.AppendHtml(resultCell);

            return row;
        }

        private TagBuilder GetFirstPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["1st"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            var resultCell = new TagBuilder("td");
            resultCell.Attributes.Add("colspan", "12");
            resultCell.InnerHtml.Append(First.FirstOrDefault());
            row.InnerHtml.AppendHtml(resultCell);

            return row;
        }

        private TagBuilder GetSecondPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["2nd"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            foreach (var result in Second)
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "6");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            return row;
        }

        private string GetThirdPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");

            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["3rd"]);
            prizeNameCell.Attributes.Add("rowspan", "2");
            row.InnerHtml.AppendHtml(prizeNameCell);

            var resultList = Third.ToList();

            foreach (var result in resultList.GetRange(0, 3))
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "4");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            var secondRow = new TagBuilder("tr");

            foreach (var result in resultList.GetRange(3, 3))
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "4");
                resultCell.InnerHtml.Append(result);
                secondRow.InnerHtml.AppendHtml(resultCell);
            }

            return $"{row.GetHtmlString()}{secondRow.GetHtmlString()}";
        }

        private TagBuilder GetFourthPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["4th"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            foreach (var result in Fourth)
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "3");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            return row;
        }

        private string GetFifthPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");

            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["5th"]);
            prizeNameCell.Attributes.Add("rowspan", "2");
            row.InnerHtml.AppendHtml(prizeNameCell);

            var resultList = Fifth.ToList();

            foreach (var result in resultList.GetRange(0, 3))
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "4");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            var secondRow = new TagBuilder("tr");

            foreach (var result in resultList.GetRange(3, 3))
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "4");
                resultCell.InnerHtml.Append(result);
                secondRow.InnerHtml.AppendHtml(resultCell);
            }

            return $"{row.GetHtmlString()}{secondRow.GetHtmlString()}";
        }

        private TagBuilder GetSixthPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["6th"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            foreach (var result in Sixth)
            {
                var resultCell = new TagBuilder("td");
                resultCell.Attributes.Add("colspan", "4");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            return row;
        }

        private TagBuilder GetSeventhPrizeHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var row = new TagBuilder("tr");
            var prizeNameCell = new TagBuilder("td");
            prizeNameCell.InnerHtml.Append(stringLocalizer["7th"]);
            row.InnerHtml.AppendHtml(prizeNameCell);

            foreach (var result in Seventh)
            {
                var resultCell = new TagBuilder("td");
                resultCell.AddCssClass("text-red");
                resultCell.Attributes.Add("colspan", "3");
                resultCell.InnerHtml.Append(result);
                row.InnerHtml.AppendHtml(resultCell);
            }

            return row;
        }
    }
}