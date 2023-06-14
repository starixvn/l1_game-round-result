using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class DragonTigerRoundResultViewModel : RoundResultViewModel
    {
        public DragonTigerCardViewModel Dragon { get; set; }

        public DragonTigerCardViewModel Tiger { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetCardContent(Dragon)}{GetCardContent(Tiger)}",
               GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            if (Dragon.Number > Tiger.Number)
            {
                return stringLocalizer["Dragon"];
            }
            else
            {
                if (Dragon.Number < Tiger.Number)
                {
                    return stringLocalizer["Tiger"];
                }
            }

            return stringLocalizer["Tie"];
        }

        private static string GetCardContent(DragonTigerCardViewModel card)
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

    public class DragonTigerCardViewModel
    {
        public byte Number { get; set; }

        public byte Type { get; set; }
    }
}