using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class DragonTigerRoundResultViewModel : RoundResultViewModel
    {
        public CardViewModel Dragon { get; set; }

        public CardViewModel Tiger { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetCardContent(Dragon)}{GetCardContent(Tiger)}",
               GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
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

            return stringLocalizer["Draw"];
        }

        private string GetCardContent(CardViewModel card)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"card card-type-{card.Type}");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(card.Number.ToString());
            tagBuilder.InnerHtml.AppendHtml(span);

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/card_{card.Type}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder.GetHtmlString();
        }
    }

    public class CardViewModel
    {
        public byte Number { get; set; }

        public byte Type { get; set; }
    }
}