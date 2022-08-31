using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class FruitSlotRoundResultViewModel : RoundResultViewModel
    {
        private readonly Dictionary<string, List<string>> GroupChoices = new Dictionary<string, List<string>>
        {
            ["bar"] = new List<string> { "bar", "bar50", "bar25" },
            ["star"] = new List<string> { "star", "star3" },
            ["tripleSeven"] = new List<string> { "tripleSeven", "tripleSeven3" },
            ["watermelon"] = new List<string> { "watermelon", "watermelon3" },
            ["bell"] = new List<string> { "bell", "bell3" },
            ["orange"] = new List<string> { "orange", "orange3" },
            ["lemon"] = new List<string> { "lemon", "lemon3" },
            ["cherry"] = new List<string> { "cherry", "cherry3" },
        };

        private const string LuckySymbol = "lucky";
        private const string Big = "big";
        private const string Small = "small";
        private const string folderImage = "/scss/images/fruitslot/{0}.png";

        public IEnumerable<string> SymbolsResult { get; set; }
        public byte NumberResult { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }
        public bool IsLucky => SettlementResult[LuckySymbol];

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultHtml(stringLocalizer),
               GetWinningOptionsHtml()
            };

            return result;
        }

        private string GetWinningOptionsHtml()
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-result");
            var tbody = new TagBuilder("tbody");
            var symbols = SymbolsResult.ToList();
            tbody.InnerHtml.AppendHtml(GetFirstRowWinningOptionHtml(symbols[0]));
            if (IsLucky)
            {
                for (var index = 0; index < symbols.Count; index++)
                {
                    tbody.InnerHtml.AppendHtml(GetRowWinningOptionHtml(symbols[index]));
                }
            }
            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private TagBuilder GetFirstRowWinningOptionHtml(string symbol)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.AddCssClass("result-cell");
            var div = new TagBuilder("div");
            if (!IsLucky)
            {
                div.InnerHtml.AppendHtml(GetWinningOptionImage(symbol));
                div.InnerHtml.Append("|");
            }
            div.InnerHtml.AppendHtml(GetBigSmallImage());
            cell.InnerHtml.AppendHtml(div);
            row.InnerHtml.AppendHtml(cell);
            return row;
        }

        private TagBuilder GetRowWinningOptionHtml(string symbol)
        {
            var row = new TagBuilder("tr");
            var cell = new TagBuilder("td");
            cell.InnerHtml.AppendHtml(GetWinningOptionImage(symbol));
            row.InnerHtml.AppendHtml(cell);
            return row;
        }

        private TagBuilder GetWinningOptionImage(string symbol)
        {
            var imgageSrc = string.Empty;
            foreach (var choice in GroupChoices)
            {
                if (choice.Value.Contains(symbol))
                {
                    imgageSrc = choice.Key;
                }
            }
            var image = new TagBuilder("img");
            image.Attributes.Add("src", string.Format(folderImage, imgageSrc));
            return image;
        }

        private string GetResultHtml(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table table-result ");
            var tbody = new TagBuilder("tbody");
            var symbols = SymbolsResult.ToList();
            tbody.InnerHtml.AppendHtml(GetSpinResultHtml(stringLocalizer, IsLucky ? LuckySymbol : symbols[0]));
            if (IsLucky)
            {
                for (var index = 0; index < symbols.Count; index++)
                {
                    tbody.InnerHtml.AppendHtml(GetExtraResultHtml(stringLocalizer, symbols[index]));
                }
            }
            table.InnerHtml.AppendHtml(tbody);

            return table.GetHtmlString();
        }

        private TagBuilder GetSpinResultHtml(IStringLocalizer<RoundResultViewModel> stringLocalizer, string symbol)
        {
            var row = new TagBuilder("tr");
            var labelCell = new TagBuilder("td");
            labelCell.AddCssClass("result-label bold");
            labelCell.InnerHtml.Append(stringLocalizer["SpinResult"]);
            row.InnerHtml.AppendHtml(labelCell);
            var resultCell = new TagBuilder("td");
            resultCell.AddCssClass("result-cell");
            var div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(GetResultImage(symbol));
            var span = new TagBuilder("span");
            span.InnerHtml.Append("| " + NumberResult);
            div.InnerHtml.AppendHtml(span);
            resultCell.InnerHtml.AppendHtml(div);
            row.InnerHtml.AppendHtml(resultCell);
            return row;
        }

        private TagBuilder GetExtraResultHtml(IStringLocalizer<RoundResultViewModel> stringLocalizer, string symbol)
        {
            var row = new TagBuilder("tr");
            var labelCell = new TagBuilder("td");
            labelCell.AddCssClass("result-label bold");
            labelCell.InnerHtml.Append(stringLocalizer["ExtraSpin"]);
            row.InnerHtml.AppendHtml(labelCell);
            var resultCell = new TagBuilder("td");
            resultCell.InnerHtml.AppendHtml(GetResultImage(symbol));
            row.InnerHtml.AppendHtml(resultCell);
            return row;
        }

        public virtual TagBuilder GetResultImage(string symbol)
        {
            const string BarSymbol = "bar";
            const string Bar100Symbol = "bar100";
            var img = new TagBuilder("img");
            img.Attributes.Add("src", string.Format(folderImage, symbol.Equals(BarSymbol) ? Bar100Symbol : symbol));
            return img;
        }

        public TagBuilder GetBigSmallImage()
        {
            var culture = CultureInfo.CurrentUICulture.Name == "vi-VN" ? ".vi-VN" : string.Empty;
            var img = new TagBuilder("img");
            img.Attributes.Add("src", string.Format(folderImage, (SettlementResult[Big] ? Big : Small) + culture));
            return img;
        }
    }
}