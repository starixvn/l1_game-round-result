using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SicBall")]
    public class SicBallRoundResultViewModel : BaseDrawResultViewModel<SicBallRoundResult, SicBallSettlementResult>
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
                tagBuilder.InnerHtml.AppendHtml(SicBallHtmlHelper.BuildBall(ball.ToString(), BallColorViewModel.GetBallColor(ball)));
            });
            tagBuilder.InnerHtml.Append($" - {Result.Balls.Sum()}");
            return tagBuilder.GetHtmlString();
        }

        public override string GetWinningOption(SicBallSettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.InnerHtml.Append(GetText(stringLocalizer, settlementResult.Big ? "big" : "small"));
            var ballValues = new List<int> { 1, 2, 3, 4, 5, 6 };
            ballValues.ForEach(ball =>
            {
                if (Result.Balls.Contains(ball))
                {
                    tagBuilder.InnerHtml.AppendHtml(", " + SicBallHtmlHelper.BuildBall(ball.ToString(), BallColorViewModel.GetBallColor(ball)));
                }
            });
            return tagBuilder.GetHtmlString();
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new TranslationBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "SicBall");
        }
    }

    public static class SicBallHtmlHelper
    {
        public static string BuildBall(string choice, string cls)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"result-column result-text bacball-result " + cls);
            tagBuilder.InnerHtml.AppendHtml(choice);

            return tagBuilder.GetHtmlString();
        }
    }
}