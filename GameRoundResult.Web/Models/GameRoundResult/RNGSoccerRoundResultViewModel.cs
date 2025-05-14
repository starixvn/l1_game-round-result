using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities.RNGSoccer;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class RNGSoccerRoundResultViewModel : RoundResultViewModel
    {
        private const string tolgeeNameSpace = "RNGSoccer";

        public RNGSoccerCardViewModel Home { get; set; }

        public RNGSoccerCardViewModel Away { get; set; }

        public RNGSoccerSettlementResultEntity SettlementResult { get; set; }

        public RNGSoccerMatchEntity Match { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            return bool.Parse(SettlementResult.GetType().GetProperty(choice).GetValue(SettlementResult, null).ToString());
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                $"{GetCardContent(Home)}{GetCardContent(Away)}",
                GetResultContent(stringLocalizer)

            };

            return result;
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (Home.Rank > Away.Rank)
            {
                return stringLocalizer["Home"];
            }
            else
            {
                if (Home.Rank < Away.Rank)
                {
                    return stringLocalizer["Away"];
                }
            }

            return stringLocalizer["Draw"];
        }

        private static string GetCardContent(RNGSoccerCardViewModel card)
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

    public class RNGSoccerCardViewModel
    {
        public byte Rank { get; set; }

        public byte Suit { get; set; }
    }
}
