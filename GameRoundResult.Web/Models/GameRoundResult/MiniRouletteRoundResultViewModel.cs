using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class MiniRouletteRoundResultViewModel : RoundResultViewModel
    {
        public byte Result { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultString()
            };

            return result;
        }

        private string GetResultString()
        {
            var span = new TagBuilder("span");
            span.AddCssClass("bold");

            if (Result == 0)
            {
                span.AddCssClass("text-green");
            }
            else
            {
                if (Roulette.RedNumbers.Any(x => x == Result))
                {
                    span.AddCssClass("text-red");
                }
            }

            span.InnerHtml.Append(Result.ToString());

            return span.GetHtmlString();
        }

        public MiniRouletteSettlementResultViewModel SettlementResult { get; set; }
    }

    public class MiniRouletteSettlementResultViewModel : RouletteSettlementResultViewModel
    {
    }
}
