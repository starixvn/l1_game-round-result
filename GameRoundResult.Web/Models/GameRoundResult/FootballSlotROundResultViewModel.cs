using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class FootballSlotRoundResultViewModel : RoundResultViewModel
    {
        private readonly Dictionary<string, List<string>> GroupChoices = new Dictionary<string, List<string>>
        {
            ["cup"] = new List<string> { "cup", "cup50", "cup25" },
            ["hostCountry"] = new List<string> { "hostCountry", "hostCountry3" },
            ["mascot"] = new List<string> { "mascot", "mascot3" },
            ["franceShirt"] = new List<string> { "franceShirt", "franceShirt3" },
            ["englandShirt"] = new List<string> { "englandShirt", "englandShirt3" },
            ["tickets"] = new List<string> { "tickets", "tickets3" },
            ["ball"] = new List<string> { "ball", "ball3" },
            ["shoes"] = new List<string> { "shoes", "shoes3" },
        };

        private const string LuckySymbol = "lucky";
        private const string Big = "big";
        private const string Small = "small";
        private const string folderImage = "/scss/images/footballslot/{0}.png";

        public IEnumerable<string> SymbolsResult { get; set; }
        public byte NumberResult { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }
        public bool IsLucky => SettlementResult[LuckySymbol];

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        private string GetResultHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        private TagBuilder GetSpinResultHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string symbol)
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

        private TagBuilder GetExtraResultHtml(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string symbol)
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
            const string cupSymbol = "cup";
            const string cup100Symbol = "cup100";
            var img = new TagBuilder("img");
            img.Attributes.Add("src", string.Format(folderImage, symbol.Equals(cupSymbol) ? cup100Symbol : symbol));
            return img;
        }

        public TagBuilder GetBigSmallImage()
        {
            var img = new TagBuilder("img");
            img.Attributes.Add("src", string.Format(folderImage, (SettlementResult[Big] ? Big : Small) + "." + CultureInfo.CurrentUICulture.Name));
            return img;
        }
    }
}