using System.Collections.Generic;
using System.Text;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class ThreeCardsRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<CardViewModel> Result { get; set; }

        public ThreeCardsSettlementResultViewModel SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(),
               GetWinningOptionsContent(stringLocalizer)
            };

            return result;
        }

        private string GetWinningOptionsContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var stringBuilder = new StringBuilder();
            var tagBuilder = new TagBuilder("span");

            tagBuilder.AddCssClass("bold");
            if (SettlementResult.Red)
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Red"]);
            }
            else
            {
                tagBuilder.InnerHtml.Append(stringLocalizer["Black"]);
            }

            stringBuilder.Append(tagBuilder.GetHtmlString());

            if (SettlementResult.Diamonds)
            {
                tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass($"img card-suit");
                tagBuilder.Attributes.Add("src", $"/scss/images/card_1.png");
                stringBuilder.Append(tagBuilder.GetHtmlString());
            }

            if (SettlementResult.Hearts)
            {
                tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass($"img card-suit");
                tagBuilder.Attributes.Add("src", $"/scss/images/card_0.png");
                stringBuilder.Append(tagBuilder.GetHtmlString());
            }

            if (SettlementResult.Spades)
            {
                tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass($"img card-suit");
                tagBuilder.Attributes.Add("src", $"/scss/images/card_3.png");
                stringBuilder.Append(tagBuilder.GetHtmlString());
            }

            if (SettlementResult.Clubs)
            {
                tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass($"img card-suit");
                tagBuilder.Attributes.Add("src", $"/scss/images/card_2.png");
                stringBuilder.Append(tagBuilder.GetHtmlString());
            }

            return stringBuilder.ToString();
        }

        private string GetResultContent()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"three-cards-result");

            tagBuilder.InnerHtml.AppendHtml(GetCardContent());

            return tagBuilder.GetHtmlString();
        }

        private TagBuilder GetCardContent()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"cards");

            foreach (var card in Result)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card));
            }

            return tagBuilder;
        }

        private static TagBuilder GetCardBuilder(CardViewModel card)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Suit}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(card.Rank);
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Suit}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder;
        }
    }

    public class ThreeCardsSettlementResultViewModel
    {
        public bool Red { get; set; }
        public bool Black { get; set; }
        public bool Diamonds { get; set; }
        public bool Hearts { get; set; }
        public bool Spades { get; set; }
        public bool Clubs { get; set; }
    }
}