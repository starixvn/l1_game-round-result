using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Text;

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
               GetResultContent(stringLocalizer),
               GetWinningOptionsContent(stringLocalizer)
            };

            return result;
        }

        private string GetWinningOptionsContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            if (SettlementResult.Dragon)
            {
                result.Add(stringLocalizer["DragonWin3Cards"]);
            }
            else
            {
                if (SettlementResult.Phoenix)
                {
                    result.Add(stringLocalizer["Phoenix"]);
                }
            }

            if (SettlementResult.Pair8Plus)
            {
                result.Add(stringLocalizer["Pair8Plus"]);
            }

            if (SettlementResult.Straight)
            {
                result.Add(stringLocalizer["Straight"]);
            }

            if (SettlementResult.Flush)
            {
                result.Add(stringLocalizer["Flush"]);
            }

            if (SettlementResult.StraightFlush)
            {
                result.Add(stringLocalizer["StraightFlush"]);
            }

            if (SettlementResult.ThreeOfAKind)
            {
                result.Add(stringLocalizer["ThreeOfAKind"]);
            }

            return string.Join(", ", result);
        }

        public string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer, bool isBetDetailPage = false)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"win3cards-result");

            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(stringLocalizer, Result.Dragon.Cards, Result.Dragon.HandRank, Result.Dragon.CardRankId, SettlementResult.Dragon && isBetDetailPage));
            tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(stringLocalizer, Result.Phoenix.Cards, Result.Phoenix.HandRank, Result.Phoenix.CardRankId, SettlementResult.Phoenix && isBetDetailPage));

            return tagBuilder.GetHtmlString();
        }

        private static TagBuilder GetCardBuilder(IStringLocalizer<RoundResultViewModel> stringLocalizer, IEnumerable<PokerCardViewModel> cards, string handRank, int cardRankId, bool isHighlight)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("cards");

            foreach (var card in cards)
            {
                tagBuilder.InnerHtml.AppendHtml(GetCardBuilder(card));
            }

            var span = new TagBuilder("span");
            if (isHighlight)
            {
                span.AddCssClass("bold");
            }
            span.InnerHtml.Append(stringLocalizer[handRank]);
            if (cardRankId >= 0)
            {
                span.InnerHtml.Append($" {Card.CardLabels[cardRankId]}");
            }
            tagBuilder.InnerHtml.AppendHtml(span);

            return tagBuilder;
        }

        private static TagBuilder GetCardBuilder(PokerCardViewModel card)
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

            return tagBuilder;
        }

        public bool IsWinningChoice(string choice)
        {
            return bool.Parse(SettlementResult.GetType().GetProperty(choice).GetValue(SettlementResult, null).ToString());
        }
    }

    public class Win3CardsResultViewModel
    {
        public Win3CardsHandViewModel Dragon { get; set; }

        public Win3CardsHandViewModel Phoenix { get; set; }
    }

    public class Win3CardsSettlementResultViewModel
    {
        public bool Dragon { get; set; }

        public bool Phoenix { get; set; }

        public bool Pair8Plus { get; set; }

        public bool Straight { get; set; }

        public bool Flush { get; set; }

        public bool StraightFlush { get; set; }

        public bool ThreeOfAKind { get; set; }

        public bool HighCard { get; set; }

        public bool DragonWin3Cards => Dragon;
    }

    public class Win3CardsHandViewModel
    {
        private readonly string[] RankHandName = {
                        "HighCard",
                        "Pair",
                        "Straight",
                        "Flush",
                        "StraightFlush",
                        "ThreeOfAKind",
                        "Killer235",
                    };

        public string HandRank => HandRankId > 0 ? RankHandName[HandRankId - 1] : string.Empty;
        public byte HandRankId { get; set; }
        public int CardRankId { get; set; }
        public IEnumerable<PokerCardViewModel> Cards { get; set; }
    }
}