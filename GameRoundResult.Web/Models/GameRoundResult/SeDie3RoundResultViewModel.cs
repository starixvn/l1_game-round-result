using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class SeDie3RoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public SeDie3SettlementResultViewModel SettlementResult { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetResult(stringLocalizer),
                GetWinningTextResult(stringLocalizer)
            };

            return result;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult.Red)
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Red"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["White"]);
            }

            tagBuilder.InnerHtml.Append($", {(TotalRed > 0 ? $"{TotalRed} {stringLocalizer["red"]}" : $"3 {stringLocalizer["white"]}")}");
            return tagBuilder.GetHtmlString();
        }
    }

    public class SeDie3ResultViewModel
    {
        public bool FirstRedChip { get; set; }
        public bool SecondRedChip { get; set; }
        public bool ThirdRedChip { get; set; }
    }

    public class SeDie3SettlementResultViewModel
    {
        public bool Red { get; set; }

        public bool White { get; set; }

        public bool OneRed { get; set; }

        public bool TwoRed { get; set; }

        public bool ThreeRed { get; set; }

        public bool ThreeWhite { get; set; }
    }
}
