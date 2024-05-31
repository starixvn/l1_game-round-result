using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class BaccaratXRoundResultViewModel : RoundResultViewModel
    {
        private const string tolgeeNameSpace = "Bac81";

        public BaccaratResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }

        public IEnumerable<BaccaratXMultiplierCard> OddsMultipliers { get; set; }

        public IEnumerable<BaccaratXMultiplierCard> AppliedMultipliers { get; set; }

        public decimal ExtraFeeRatio { get; set; }

        public bool IsMultiplierCardApplied(BaccaratCard card) => AppliedMultipliers.Any(x => x.Type == card.Type && x.Number == card.Number);

        public IEnumerable<BaccaratCard> ConvertToCardList(BaccaratCardResult side)
        {
            var list = new List<BaccaratCard> { side.FirstCard, side.SecondCard };
            if (side.ThirdCard != null)
            {
                list.Add(side.ThirdCard);
            }

            return list;
        }

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
            string result;

            if (SettlementResult["player"])
            {
                result = stringLocalizer.GetStringWithNamcespace("glossary_option_player", tolgeeNameSpace);
            }
            else
            {
                result = SettlementResult["banker"] ? stringLocalizer.GetStringWithNamcespace("glossary_option_banker", tolgeeNameSpace)
                    : stringLocalizer.GetStringWithNamcespace("glossary_option_tie", tolgeeNameSpace);
            }

            if (SettlementResult["playerPair"])
            {
                result = $"{result}, {stringLocalizer.GetStringWithNamcespace("glossary_option_player_pair", tolgeeNameSpace)}";
            }

            if (SettlementResult["bankerPair"])
            {
                result = $"{result}, {stringLocalizer.GetStringWithNamcespace("glossary_option_banker_pair", tolgeeNameSpace)}";
            }

            return result;
        }

        private string GetResultContent()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"baccarat-result");

            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(ConvertToCardList(Result.Player)));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(ConvertToCardList(Result.Banker)));

            return tagBuilder.GetHtmlString();
        }

        private static TagBuilder GetCardBuilder(IEnumerable<BaccaratCard> cards)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"cards");

            foreach (var card in cards)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card));
            }

            return tagBuilder;
        }

        private static TagBuilder GetCardBuilder(BaccaratCard card)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Type}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(Core.Constants.Card.CardLabels[card.Number]);
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Type}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder;
        }
    }
}