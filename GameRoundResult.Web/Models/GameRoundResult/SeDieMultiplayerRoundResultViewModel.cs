using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class SeDieMultiplayerRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public SeDieMultiplayerSettlementResultViewModel SettlementResult { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return SeDieOriginalGamesHelper.GetChipContent(RedChips);
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return SeDieOriginalGamesHelper.GetResultContent(SettlementResult.Even, TotalRed, stringLocalizer);
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                SeDieOriginalGamesHelper.GetChipContent(RedChips),
                SeDieOriginalGamesHelper.GetResultContent(SettlementResult.Even, TotalRed, stringLocalizer)
            };

            return result;
        }
    }

    public class SeDieMultiplayerSettlementResultViewModel : SeDieSettlementResultViewModel { }

    public static class SeDieOriginalGamesHelper
    {
        public static string GetChipContent(IEnumerable<bool> redChips)
        {
            var result = new List<string>();

            foreach (var chip in redChips)
            {
                var tagBuilder = new TagBuilder("i");

                tagBuilder.AddCssClass(chip ? "red-chip" : "white-chip");

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }

        public static string GetResultContent(bool isEven, int totalRed, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (isEven)
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Even"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Odd"]);
            }

            tagBuilder.InnerHtml.Append($", {(totalRed > 0 ? $"{totalRed} {stringLocalizer["red"]}" : $"{SeDie.NumberOfChips} {stringLocalizer["white"]}")}");
            return tagBuilder.GetHtmlString();
        }
    }
}
