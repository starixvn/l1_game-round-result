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

        public Dictionary<string, bool> SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetDiceContent(),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        public string GetDiceContent()
        {
            var div = new TagBuilder("div");
            div.AddCssClass("football-dice-result");

            div.InnerHtml.AppendHtml(GetResult("home", Result.HomeValue, Result.Home));
            div.InnerHtml.AppendHtml(GetResult("away", Result.AwayValue, Result.Away));

            return div.GetHtmlString();
        }

        private TagBuilder GetResult(string choice, int value, IEnumerable<byte> dices)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("dice-list");

            foreach (var dice in dices)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/football-dice/dice-{choice}-{dice}.png");

                div.InnerHtml.AppendHtml(tagBuilder);
            }

            div.InnerHtml.AppendHtml(SettlementResult[choice] ? $"<b>{value}</b>" : $"{value}");

            return div;
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var winningKey = SettlementResult.FirstOrDefault(choice => choice.Value == true).Key;
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");

            if (SettlementResult["home"])
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Home"]);
            }

            if (SettlementResult["away"])
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Away"]);
            }

            if (SettlementResult["draw"])
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