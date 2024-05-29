using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("LuckyThree")]
    public class LuckyThreeRoundResultViewModel : BaseDrawResultViewModel<LuckyThreeRoundResult, LuckyThreeSettlementResult>
    {
        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>()
            {
               base.ToDataTableArray(stringLocalizer).First(),
               DrawId.ToString(),
               $"{GetResult()}",
               $"{GetWinningTextResult(stringLocalizer)}",
            };

            return result;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetResult();
        }

        public string GetResult()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");
            Result.Balls.ForEach(ball =>
            {
                tagBuilder.InnerHtml.AppendHtml(BuildBall(ball.ToString(), BallColorViewModel.GetBallColor(ball)));
            });
            tagBuilder.InnerHtml.Append($" - {Result.Balls.Sum()}");
            return tagBuilder.GetHtmlString();
        }

        private TagBuilder BuildBall(string choice, string cls)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"result-column result-text bacball-result " + cls);
            tagBuilder.InnerHtml.AppendHtml(choice);

            return tagBuilder;
        }

        public override string GetWinningOption(LuckyThreeSettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.InnerHtml.Append(GetText(stringLocalizer, settlementResult.Over ? "over" : "under") + ", ");
            var subChoices = new List<string>() { "Blue3", "Blue2", "Red2", "Red3" };
            var redCount = subChoices.FindIndex(choice => bool.Parse(settlementResult.GetType().GetProperty(choice).GetValue(settlementResult, null).ToString()));
            for (var i = 1; i <= 3; i++)
            {
                tagBuilder.InnerHtml.AppendHtml(SeBallHtmlHelper.RenderChip(redCount >= i));
            }
            return tagBuilder.GetHtmlString();
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new TranslationBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "LuckyThree");
        }
    }
}