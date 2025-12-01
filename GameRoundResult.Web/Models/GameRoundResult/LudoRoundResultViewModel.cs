using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class LudoRoundResultViewModel : RoundResultViewModel
    {
        private const string tolgeeNameSpace = "Ludo";
        public List<int> Dice { get; set; }

        public int Total => Dice.Sum(x => x);

        public LudoSettlementResultEntity SettlementResult { get; set; }

        public MultiplierViewModel Multiplier { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetResult(stringLocalizer),

                //GetMultiplier(stringLocalizer),

                GetWinningTextResult(stringLocalizer)
            };

            return result;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("dice-list");

            foreach (var dice in Dice)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/dice_{dice}.png");

                div.InnerHtml.AppendHtml(tagBuilder);
            }

            return div.GetHtmlString();
        }

        public string GetMultiplier(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var multiplierText = Multiplier != null ? $"{Multiplier.Value}x" : string.Empty;
            var choiceText = Multiplier?.Choice?.ToLower() switch
            {
                "seven" => "7",
                var choice when !string.IsNullOrEmpty(choice) => choice,
                _ => string.Empty
            };

            var localizedChoiceKey = !string.IsNullOrEmpty(choiceText) ? $"glossary_{choiceText}" : string.Empty;
            var localizedResult = !string.IsNullOrEmpty(localizedChoiceKey)
                ? stringLocalizer.GetStringWithNamcespace(localizedChoiceKey, tolgeeNameSpace)
                : string.Empty;

            var multiplierTag = new TagBuilder("span");
            multiplierTag.AddCssClass("bold");
            multiplierTag.AddCssClass("bet-win-text");
            multiplierTag.InnerHtml.Append(multiplierText);

            var resultTag = new TagBuilder("span");
            resultTag.AddCssClass("cointoss-result");
            resultTag.InnerHtml.AppendHtml(multiplierTag);
            resultTag.InnerHtml.AppendHtml($"&nbsp;- {localizedResult}");

            return resultTag.GetHtmlString();
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("text");
            string result = "";

            var names = SettlementResult.GetType().GetProperties()
                  .Where(p => p.PropertyType == typeof(bool) &&
                              (bool)p.GetValue(SettlementResult))
                  .Select(p => GetText(stringLocalizer, LudoTicketViewModel.TransformChoice(p.Name)));

            result = string.Join(", ", names);
            tagBuilder.InnerHtml.Append(result);

            return tagBuilder.GetHtmlString();
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.Choice, "VNLudo");
        }
    }

    public class LudoSettlementBetEntity
    {
        public decimal Odd { get; set; }
        public decimal Even { get; set; }
        public decimal Big { get; set; }
        public decimal Small { get; set; }
        public decimal Kick { get; set; }
        public decimal NoKick { get; set; }
        public decimal Move { get; set; }
        public decimal NoMove { get; set; }
        public decimal Release { get; set; }
        public decimal NoRelease { get; set; }
        public decimal GoStable { get; set; }
        public decimal NoStable { get; set; }
    }
}
