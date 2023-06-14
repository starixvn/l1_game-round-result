using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class BigSmallRoundResultViewModel : RoundResultViewModel
    {
        public BigSmallSettlementResultViewModel SettlementResult { get; set; }
        public IEnumerable<byte> Dices { get; set; }

        public int Total => Dices.Sum(x => x);

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetDiceContent(),
                Total.ToString(),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetDiceContent()
        {
            var div = new TagBuilder("div");
            div.AddCssClass("dice-list");

            foreach (var dice in Dices)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/dice_{dice}.png");

                div.InnerHtml.AppendHtml(tagBuilder);
            }

            return div.GetHtmlString();
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");

            tagBuilder.AddCssClass("bold");
            if (SettlementResult.Big)
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Big"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Small"]);
            }

            return tagBuilder.GetHtmlString();
        }
    }

    public class BigSmallSettlementResultViewModel
    {
        public bool Big { get; set; }

        public bool Small { get; set; }
    }
}