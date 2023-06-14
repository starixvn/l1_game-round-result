using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class RouletteRoundResultViewModel : RoundResultViewModel
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

        public RouletteSettlementResultViewModel SettlementResult { get; set; }
    }

    public class RouletteSettlementResultViewModel
    {
        public IEnumerable<string> StraightUp { get; set; }

        public IEnumerable<string> Split { get; set; }

        public IEnumerable<string> Street { get; set; }

        public IEnumerable<string> Triangle { get; set; }

        public IEnumerable<string> Corner { get; set; }

        public IEnumerable<string> FourNumbers { get; set; }

        public IEnumerable<string> Line { get; set; }

        public IEnumerable<string> Column { get; set; }

        public IEnumerable<string> Dozen { get; set; }

        public IEnumerable<string> RedBlack { get; set; }

        public IEnumerable<string> OddEven { get; set; }

        public IEnumerable<string> BigSmall { get; set; }
    }
}