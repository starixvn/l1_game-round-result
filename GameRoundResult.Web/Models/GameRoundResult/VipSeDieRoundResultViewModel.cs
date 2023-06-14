using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public bool IsEven { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetChipContent(),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private const int maxChips = 4;

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

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (IsEven)
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Even"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Odd"]);
            }

            tagBuilder.InnerHtml.Append($", {(TotalRed > 0 ? stringLocalizer["{0} red", TotalRed] : stringLocalizer["{0} white", maxChips])}");
            return tagBuilder.GetHtmlString();
        }
    }
}