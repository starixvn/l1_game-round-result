using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class SeDieRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public bool IsEven => TotalRed % 2 == 0;

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

                if (chip)
                {
                    tagBuilder.AddCssClass("red-chip");
                }
                else
                {
                    tagBuilder.AddCssClass("white-chip");
                }

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }

        private string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
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

            if (TotalRed == 2)
            {
                return tagBuilder.GetHtmlString();
            }

            tagBuilder.InnerHtml.Append($", {(TotalRed > 0 ? stringLocalizer["{0} red", TotalRed] : stringLocalizer["{0} white", 4])}");
            return tagBuilder.GetHtmlString();
        }
    }
}