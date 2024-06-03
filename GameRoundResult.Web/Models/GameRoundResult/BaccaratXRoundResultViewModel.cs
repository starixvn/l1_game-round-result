using System;
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

        public IEnumerable<BaccaratXMultiplierCard> OddsMultipliers { get; set; } = Enumerable.Empty<BaccaratXMultiplierCard>();

        public IEnumerable<BaccaratXMultiplierCard> AppliedMultipliers { get; set; } = Enumerable.Empty<BaccaratXMultiplierCard>();

        public decimal ExtraFeeRatio { get; set; }

        public bool IsMultiplierCardApplied(BaccaratCard card) => AppliedMultipliers.Any(x => x.Type == card.Type && x.Number == card.Number);

        public string DisplayPlayerCardMultiplier(BaccaratCard card)
        {
            if (SettlementResult["tie"] || SettlementResult["player"] || SettlementResult["playerPair"])
            {
                return GetCardMultiplier(card);
            }

            return string.Empty;
        }

        public string DisplayBankerCardMultiplier(BaccaratCard card)
        {
            if (SettlementResult["tie"] || SettlementResult["banker"] || SettlementResult["bankerPair"])
            {
                return GetCardMultiplier(card);
            }

            return string.Empty;
        }

        private string GetCardMultiplier(BaccaratCard card)
        {
            var multiplierCard = AppliedMultipliers.FirstOrDefault(x => x.Number == card.Number && x.Type == card.Type);

            if (multiplierCard != null)
            {
                return FormatMultiplier(multiplierCard.Value);
            }

            return string.Empty;
        }

        public string FormatMultiplier(byte multiplier) => $"{multiplier}x";

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
               GetResult(stringLocalizer),
               GetWinningTextResult(stringLocalizer)
            };

            return result;
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
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

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"baccarat-result {(AppliedMultipliers.Any() ? "with-multipliers" : string.Empty)}");

            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(ConvertToCardList(Result.Player), DisplayPlayerCardMultiplier));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(ConvertToCardList(Result.Banker), DisplayBankerCardMultiplier));

            return tagBuilder.GetHtmlString();
        }

        private TagBuilder GetCardBuilder(IEnumerable<BaccaratCard> cards, Func<BaccaratCard, string> displayMultiplier)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"cards");

            foreach (var card in cards)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card, displayMultiplier));
            }

            return tagBuilder;
        }

        private TagBuilder GetCardBuilder(BaccaratCard card, Func<BaccaratCard, string> displayMultiplier)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Type}");

            var multiplierDiv = new TagBuilder("div");
            multiplierDiv.AddCssClass("multiplier");
            multiplierDiv.InnerHtml.Append(displayMultiplier(card));
            tagBuilder.InnerHtml.AppendHtml(multiplierDiv);

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