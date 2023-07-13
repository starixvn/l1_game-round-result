using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class SeDieRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public SeDieSettlementResultViewModel SettlementResult { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

            tagBuilder.InnerHtml.Append($", {(TotalRed > 0 ? $"{TotalRed} {stringLocalizer["red"]}" : $"{SeDie.NumberOfChips} {stringLocalizer["white"]}")}");
            return tagBuilder.GetHtmlString();
        }
    }

    public class SeDieSettlementResultViewModel
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool TwoRed { get; set; }

        public bool ThreeRed { get; set; }

        public bool FourRed { get; set; }

        public bool ThreeWhite { get; set; }

        public bool FourWhite { get; set; }
    }
}