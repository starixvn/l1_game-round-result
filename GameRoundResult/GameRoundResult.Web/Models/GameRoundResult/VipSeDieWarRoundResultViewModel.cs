using System.Collections.Generic;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieWarRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> PlayerChips { get; set; }
        public IEnumerable<bool> BankerChips { get; set; }

        public bool IsEven { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetChipContent(PlayerChips),
                GetChipContent(BankerChips),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetChipContent(IEnumerable<bool> chips)
        {
            var result = new List<string>();

            foreach (var chip in chips)
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

            return tagBuilder.GetHtmlString();
        }
    }
}