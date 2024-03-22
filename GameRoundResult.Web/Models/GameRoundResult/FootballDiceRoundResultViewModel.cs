using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class FootballDiceRoundResultViewModel : RoundResultViewModel
    {
        public FootballDiceResultViewModel Result { get; set; }

        public FootballDiceSettlementResultViewModel SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetDiceContent(),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetDiceContent()
        {
            var div = new TagBuilder("div");
            div.AddCssClass("dice-list");


            foreach (var dice in Result.Home)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/football-dice/dice-home-{dice}.png");

                div.InnerHtml.AppendHtml(tagBuilder);
            }

            var resultWrapper = new TagBuilder("div");
            var result = new TagBuilder("span");
            result.InnerHtml.AppendHtml(SettlementResult.Home ? $"<b>{Result.HomeValue}</b>" : $"{Result.HomeValue}");
            result.InnerHtml.Append(" | ");
            result.InnerHtml.AppendHtml(SettlementResult.Away ? $"<b>{Result.AwayValue}</b>" : $"{Result.AwayValue}");

            resultWrapper.AddCssClass("football-dice-result");
            resultWrapper.InnerHtml.AppendHtml(result);
            div.InnerHtml.AppendHtml(resultWrapper);

            foreach (var dice in Result.Away)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/football-dice/dice-away-{dice}.png");

                div.InnerHtml.AppendHtml(tagBuilder);
            }


            return div.GetHtmlString();
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult.Home)
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Home"]);
            }
           
            if(SettlementResult.Away)
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Away"]);
            }

            if(SettlementResult.Draw)
            {
                tagBuilder.InnerHtml.Append(stringLocalizer["Draw"]);
            }

            return tagBuilder.GetHtmlString();
        }
    }

    public class FootballDiceResultViewModel
    {
        public IEnumerable<byte> Home { get; set; }
        public IEnumerable<byte> Away { get; set; }
        public int HomeValue { get; set; }
        public int AwayValue { get; set; }
    }

    public class FootballDiceSettlementResultViewModel
    {
        public bool Home { get; set; }

        public bool Away { get; set; }

        public bool Draw { get; set; }
    }
}