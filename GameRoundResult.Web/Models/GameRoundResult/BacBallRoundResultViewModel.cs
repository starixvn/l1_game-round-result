using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BacBallRoundResultViewModel : RoundResultViewModel
    {
        public long DrawId { get; set; }

        public BacBallRoundResult Result { get; set; }

        public BacBallSettlementResult SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>()
            {
               base.ToDataTableArray(stringLocalizer).First(),
               DrawId.ToString(),

               $"{GetResult()}",
               $"{GetWinningOption(SettlementResult, stringLocalizer)}",
               
            };

            return result;
        }

        private string GetResult()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(Result.Player.ToString(), BallColorViewModel.GetBallColor(Result.Player)));
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(Result.Banker.ToString(), BallColorViewModel.GetBallColor(Result.Banker)));

            return tagBuilder.GetHtmlString();
        }

        private TagBuilder BuildBall(string choice, string cls)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"result-column result-text bacball-result " + cls);
            tagBuilder.InnerHtml.AppendHtml(choice);

            return tagBuilder;
        }

        public string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");

            var winningText = GetWinningOption(SettlementResult, stringLocalizer);
            var contentBuilder = new TagBuilder("div");
            contentBuilder.AddCssClass($"result-row");
            contentBuilder.InnerHtml.AppendHtml(winningText);
            tagBuilder.InnerHtml.AppendHtml(contentBuilder);

            return tagBuilder.GetHtmlString();
        }

        public string GetWinningOption(BacBallSettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            string option;
            if (settlementResult.Player)
            {
                option = GetText(stringLocalizer, "player");
            }
            else if (settlementResult.Banker)
            {
                option = GetText(stringLocalizer, "banker");
            }
            else
            {
                option = GetText(stringLocalizer, "tie");
            }

            return option;
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new TranslationBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "BacBall");
        }
    }
}