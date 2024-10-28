using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class SevenUpDownRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }

        public int Total => Dices.Sum(x => x);

        public SevenUpDownSettlementResultViewModel SettlementResult { get; set; }

        public MultiplierViewModel Multiplier { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetDiceContent(),
                GetWinningTextResult(stringLocalizer)
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

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult.Seven)
            {
                tagBuilder.InnerHtml.Append(stringLocalizer["Seven"]);
            }
            else
            {
                if (SettlementResult.Up)
                {
                    tagBuilder.InnerHtml.Append(stringLocalizer["Up"]);
                }
                else
                {
                    tagBuilder.InnerHtml.Append(stringLocalizer["Down"]);
                }
            }
   
            return tagBuilder.GetHtmlString();
        }
    }
    public class MultiplierViewModel
    {
        public int Value { get; set; }
        public string Choice { get; set; }
    }

    public class SevenUpDownSettlementResultViewModel
    {
        public bool Up { get; set; }

        public bool Down { get; set; }

        public bool Seven { get; set; }
    }
}
