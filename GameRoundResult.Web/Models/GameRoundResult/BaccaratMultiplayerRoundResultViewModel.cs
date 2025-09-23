using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class BaccaratMultiplayerRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<DragonTigerCardViewModel> PlayerCards { get; set; }

        public IEnumerable<DragonTigerCardViewModel> BankerCards { get; set; }

        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Tie { get; set; }
        public bool AnyPair { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(),
               GetWinningOptionsContent(stringLocalizer)
            };

            return result;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetResultContent();
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetWinningOptionsContent(stringLocalizer);
        }

        private string GetWinningOptionsContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            string result;

            if (Player)
            {
                result = stringLocalizer["Player"];
            }
            else
            {
                result = Banker ? stringLocalizer["Banker"] : stringLocalizer["Tie"];
            }

            if (AnyPair)
            {
                result = $"{result}, {stringLocalizer["PlayerPair"]}";
            }

            return result;
        }

        private string GetResultContent()
        {
            var tagBuilder = CreateDivWithClass("baccarat-result");
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(PlayerCards));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(BankerCards));

            return tagBuilder.GetHtmlString();
        }

        private static TagBuilder GetCardBuilder(IEnumerable<DragonTigerCardViewModel> cards)
        {
            var tagBuilder = CreateDivWithClass("cards");

            foreach (var card in cards)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card));
            }

            return tagBuilder;
        }

        private static TagBuilder GetCardBuilder(DragonTigerCardViewModel card)
        {
            var tagBuilder = CreateDivWithClass($"card card-type-{card.Type}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(Card.CardLabels[card.Number]);
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Type}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder;
        }

        private static TagBuilder CreateDivWithClass(string cssClass)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass(cssClass);
            return tagBuilder;
        }
    }
}
