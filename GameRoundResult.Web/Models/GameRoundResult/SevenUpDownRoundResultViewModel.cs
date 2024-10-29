using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class SevenUpDownRoundResultViewModel : RoundResultViewModel
    {
        private const string tolgeeNameSpace = "7Up7Down";
        public IEnumerable<byte> Dices { get; set; }

        public int Total => Dices.Sum(x => x);

        public SevenUpDownSettlementResultViewModel SettlementResult { get; set; }

        public MultiplierViewModel Multiplier { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetResult(stringLocalizer),

                GetMultiplier(stringLocalizer),

                GetWinningTextResult(stringLocalizer)
            };

            return result;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        public string GetMultiplier(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var multiplierText = Multiplier != null ? $"{Multiplier.Value}x" : string.Empty;
            var choiceText = Multiplier?.Choice?.ToLower() switch
            {
                "seven" => "7",
                var choice when !string.IsNullOrEmpty(choice) => choice,
                _ => string.Empty
            };

            var localizedChoiceKey = !string.IsNullOrEmpty(choiceText) ? $"glossary_{choiceText}" : string.Empty;
            var localizedResult = !string.IsNullOrEmpty(localizedChoiceKey)
                ? stringLocalizer.GetStringWithNamcespace(localizedChoiceKey, tolgeeNameSpace)
                : string.Empty;

            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");
            tagBuilder.InnerHtml.Append($"{multiplierText} - {localizedResult}");
            return tagBuilder.GetHtmlString();
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");
            tagBuilder.InnerHtml.Append(Total.ToString());
            if (Total != 7)
            {
                tagBuilder.InnerHtml.Append(" - ");
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
