using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class DragonTigerFightRoundResultViewModel : RoundResultViewModel
    {       
        public DragonTigerFightResultViewModel Result { get; set; }

        public DragonTigerFightSettlementResultViewModel SettlementResult { get; set; }

        public virtual bool IsWinningChoice(string choice)
        {
            return bool.Parse(SettlementResult.GetType().GetProperty(choice).GetValue(SettlementResult, null).ToString());
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetCardContent(Result.Dragon)}{GetCardContent(Result.Tiger)}",
               GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            List<string> result = new List<string> { };

            if (Result.Dragon.Rank > Result.Tiger.Rank)
            {
                result.Add(GetText(stringLocalizer, "dragon"));
            }
            else if(Result.Dragon.Rank < Result.Tiger.Rank)
            {
                result.Add(GetText(stringLocalizer, "tiger"));                
            }
            else
            {
                result.Add(GetText(stringLocalizer, "tie"));
            }

            if(Card.CardSuites[Result.Dragon.Suit] == Card.BlackCard)
            {
                result.Add(GetText(stringLocalizer, "blackDragon"));
            }
            else if(Card.CardSuites[Result.Dragon.Suit] == Card.RedCard)
            {
                result.Add(GetText(stringLocalizer, "redDragon"));
            }

            if (Card.CardSuites[Result.Tiger.Suit] == Card.BlackCard)
            {
                result.Add(GetText(stringLocalizer, "blackTiger"));
            }
            else if (Card.CardSuites[Result.Tiger.Suit] == Card.RedCard)
            {
                result.Add(GetText(stringLocalizer, "redTiger"));
            }

            return string.Join(", ", result.ToArray());
        }

        private string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            return stringLocalizer.GetStringWithNamcespace("glossary_" + key, "DragonTigerFight");
        }

        private static string GetCardContent(DragonTigerFightCard card)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Suit}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(Card.CardLabels[card.Rank]);
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Suit}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder.GetHtmlString();
        }
    }

    public class DragonTigerFightResultViewModel
    {
        public DragonTigerFightCard Dragon { get; set; }

        public DragonTigerFightCard Tiger { get; set; }
    }

    public class DragonTigerFightCard
    {
        public byte Rank { get; set; }

        public byte Suit { get; set; }
    }

    public class DragonTigerFightSettlementResultViewModel
    {
        public bool Dragon { get; set; }

        public bool Tiger { get; set; }

        public bool Tie { get; set; }

        public bool BlackDragon { get; set; }

        public bool RedDragon { get; set; }

        public bool BlackTiger { get; set; }

        public bool RedTiger { get; set; }
    }
}