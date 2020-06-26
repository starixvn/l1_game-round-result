using System.Collections.Generic;
using System.Linq;
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
            var playerCardString = string.Join("", PlayerCards.Select(x => GetCardContent(x)));
            var bankerCardString = string.Join("", BankerCards.Select(x => GetCardContent(x)));


            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{playerCardString}{bankerCardString}",
               GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            string result;

            if (Player)
            {
                result = stringLocalizer["Player"];
            }
            else
            {
                if (Banker)
                {
                    result = stringLocalizer["Banker"];
                }
                else
                {
                    result = stringLocalizer["Tie"];
                }
            }

            if (PlayerPair)
            {
                result = $"{result}, {stringLocalizer["PlayerPair"]}";
            }
            else
            {
                if (BankerPair)
                {
                    result = $"{result}, {stringLocalizer["BankerPair"]}";
                }
            }

            result = $"{result}, {(Big ? stringLocalizer["Big"] : stringLocalizer["Small"])}";
            return result;
        }

        private string GetCardContent(CardViewModel card)
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

            return tagBuilder.GetHtmlString();
        }
    }
}