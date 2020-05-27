using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class KenoProMaxRoundResultViewModel : RoundResultViewModel
    {
        public IList<byte> Result { get; set; }

        public int Total => Result.Sum(x => x);

        public bool IsEven { get; set; }

        public bool IsBig { get; set; }

        public bool IsEarth { get; set; }

        public bool IsFire { get; set; }

        public bool IsWood { get; set; }

        public bool IsWater { get; set; }

        public bool IsGold { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(),
               Total.ToString(),
               GetBigSmallContent(stringLocalizer),
               GetOddEvenContent(stringLocalizer),
               GetElementContent(stringLocalizer)
            };

            return result;
        }

        private string GetResultContent()
        {
            var stringContents = new List<string>();

            for (var i = 0; i < Result.Count; i++)
            {
                var tagBuilder = new TagBuilder("span");
                tagBuilder.AddCssClass("circle");
                tagBuilder.InnerHtml.Append(Result[i].ToString());
                stringContents.Add(tagBuilder.GetHtmlString());

                if (i == 9)
                {
                    var lineBreak = new TagBuilder("br")
                    {
                        TagRenderMode = TagRenderMode.SelfClosing
                    };
                    stringContents.Add(lineBreak.GetHtmlString());
                }
            }

            return string.Join("", stringContents);
        }

        private string GetBigSmallContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("bold");
            if (IsBig)
            {
                span.AddCssClass("text-red");
                span.InnerHtml.Append(stringLocalizer["Big"]);
            }
            else
            {
                span.AddCssClass("text-blue");
                span.InnerHtml.Append(stringLocalizer["Small"]);
            }

            return span.GetHtmlString();
        }

        private string GetOddEvenContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("bold");
            if (IsEven)
            {
                span.AddCssClass("text-blue");
                span.InnerHtml.Append(stringLocalizer["Even"]);
            }
            else
            {
                span.AddCssClass("text-red");
                span.InnerHtml.Append(stringLocalizer["Odd"]);
            }

            return span.GetHtmlString();
        }

        private string GetElementContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var span = new TagBuilder("span");
            span.AddCssClass("bold");
            if (IsEarth)
            {
                span.AddCssClass("text-earth");
                span.InnerHtml.Append(stringLocalizer["Earth"]);
            }
            if (IsGold)
            {
                span.AddCssClass("text-gold");
                span.InnerHtml.Append(stringLocalizer["Gold"]);
            }
            if (IsWood)
            {
                span.AddCssClass("text-wood");
                span.InnerHtml.Append(stringLocalizer["Wood"]);
            }
            if (IsWater)
            {
                span.AddCssClass("text-water");
                span.InnerHtml.Append(stringLocalizer["Water"]);
            }
            if (IsFire)
            {
                span.AddCssClass("text-fire");
                span.InnerHtml.Append(stringLocalizer["Fire"]);
            }

            return span.GetHtmlString();
        }
    }
}