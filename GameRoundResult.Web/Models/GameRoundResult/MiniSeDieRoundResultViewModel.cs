using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class MiniSeDieRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public MiniSeDieSettlementResultViewModel SettlementResult { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetChipContent(),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetChipContent()
        {
            var result = new List<string>();

            foreach (var chip in RedChips)
            {
                var tagBuilder = new TagBuilder("i");

                tagBuilder.AddCssClass(chip ? "red-chip" : "white-chip");

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }

        private string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult.Even)
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Even"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Odd"]);
            }

            if (TotalRed == 2)
            {
                return tagBuilder.GetHtmlString();
            }

            tagBuilder.InnerHtml.Append($", {(TotalRed > 0 ? stringLocalizer["{0} red", TotalRed] : stringLocalizer["{0} white", 4])}");
            return tagBuilder.GetHtmlString();
        }
    }


    public class MiniSeDieSettlementResultViewModel
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool ThreeRed { get; set; }

        public bool FourRed { get; set; }

        public bool ThreeWhite { get; set; }

        public bool FourWhite { get; set; }
    }
}