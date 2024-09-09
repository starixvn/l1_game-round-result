using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class KaraKrusRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> HeadChips { get; set; }

        public KaraKrusSettlementResultViewModel SettlementResult { get; set; }

        public int TotalHead => HeadChips.Count(x => x);

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

            foreach (var chip in HeadChips)
            {
                var tagBuilder = new TagBuilder("i");

                tagBuilder.AddCssClass(chip ? "dice-kara" : "dice-krus");

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult.Kara)
            {
                tagBuilder.InnerHtml.Append(stringLocalizer["Kara"]);
            }
            else
            {
                tagBuilder.InnerHtml.Append(stringLocalizer["Krus"]);
            }

            tagBuilder.InnerHtml.Append($", {(TotalHead > 0 ? $"{TotalHead} {stringLocalizer["Head"]}" : $"3 {stringLocalizer["Tail"]}")}");
            return tagBuilder.GetHtmlString();
        }
    }

    public class KaraKrusSettlementResultViewModel
    {
        public bool Kara { get; set; }

        public bool Krus { get; set; }

        public bool OneHead { get; set; }

        public bool TwoHead { get; set; }

        public bool ThreeHead { get; set; }

        public bool ThreeTail { get; set; }
    }
}
