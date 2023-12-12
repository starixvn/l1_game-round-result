using GameRoundResult.Web.Configuration;
using System.Collections.Generic;
using GameRoundResult.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameRoundResult.Web.Extensions;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    public class CrashGameRoundResultViewModel : RoundResultViewModel
    {
        public decimal Result { get; set; }
        public string DisplayResult => $"{Result.Format2Decimals()}x";

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(stringLocalizer),
            };

            return result;
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");

            tagBuilder.AddCssClass("bold");
            var span = new TagBuilder("span");
            span.InnerHtml.Append(Result + "x");
          
            tagBuilder.InnerHtml.AppendHtml(span);
            return tagBuilder.GetHtmlString();
        }
    }
}