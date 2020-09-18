using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class BaccaratRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<CardViewModel> PlayerCards { get; set; }

        public IEnumerable<CardViewModel> BankerCards { get; set; }

        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Tie { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool PlayerPair { get; set; }
        public bool BankerPair { get; set; }
        public bool Natural { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(),
               GetWinningOptionsContent(stringLocalizer)
            };

            return result;
        }

        private string GetWinningOptionsContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
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

            if (PlayerPair)
            {
                result = $"{result}, {stringLocalizer["PlayerPair"]}";
            }

            if (BankerPair)
            {
                result = $"{result}, {stringLocalizer["BankerPair"]}";
            }

            result = $"{result}, {(Big ? stringLocalizer["Big"] : stringLocalizer["Small"])}";
            return result;
        }

        private string GetResultContent()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"baccarat-result");

            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(PlayerCards));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(BankerCards));

            return tagBuilder.GetHtmlString();
        }

        private static TagBuilder GetCardBuilder(IEnumerable<CardViewModel> cards)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"cards");

            foreach (var card in cards)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card));
            }

            return tagBuilder;
        }

        private static TagBuilder GetCardBuilder(CardViewModel card)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Type}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(Card.CardLabels[card.Number]);
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Type}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder;
        }
    }
}