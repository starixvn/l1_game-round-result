using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class Win3CardsRoundResultViewModel : RoundResultViewModel
    {
        public Win3CardsResultViewModel Result { get; set; }

        public Win3CardsSettlementResultViewModel SettlementResult { get; set; }
        


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

            if (SettlementResult.Dragon)
            {
                result = stringLocalizer["Dragon"];
            }
            else
            {
                result = SettlementResult.Phoenix ? stringLocalizer["Phoenix"] : stringLocalizer["Tie"];
            }

            if (SettlementResult.Straight)
            {
                result = $"{result}, {stringLocalizer["Straight"]}";
            }

            if (SettlementResult.StraightFlush)
            {
                result = $"{result}, {stringLocalizer["Straight Flush"]}";
            }

            if (SettlementResult.Pair8Plus)
            {
                result = $"{result}, {stringLocalizer["Pair 8 Plus"]}";
            }

            if (SettlementResult.FLush)
            {
                result = $"{result}, {stringLocalizer["Flush"]}";
            }

            if (SettlementResult.HighCard)
            {
                result = $"{result}, {stringLocalizer["High Card"]}";
            }

            if (SettlementResult.ThreeKind)
            {
                result = $"{result}, {stringLocalizer["Three of a Kind"]}";
            }

            return result;
        }

        private string GetResultContent()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"baccarat-result");

            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(Result.DragonCards));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(Result.PhoenixCards));

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

    public class Win3CardsResultViewModel
    {
        public IEnumerable<CardViewModel> DragonCards { get; set; }

        public IEnumerable<CardViewModel> PhoenixCards { get; set; }
    }

    public class Win3CardsSettlementResultViewModel
    {
        public bool Dragon { get; set; }

        public bool Phoenix { get; set; }

        public bool Pair8Plus { get; set; }

        public bool Straight { get; set; }

        public bool FLush { get; set; }

        public bool StraightFlush { get; set; }

        public bool ThreeKind { get; set; }

        public bool HighCard { get; set; }
    }
}
