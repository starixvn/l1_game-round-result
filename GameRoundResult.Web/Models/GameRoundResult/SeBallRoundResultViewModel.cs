using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class SeBallRoundResultViewModel : RoundResultViewModel
    {
        public long DrawId { get; set; }

        public SeBallRoundResult Result { get; set; }

        public SeBallSettlementResult SettlementResult { get; set; }

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
                tagBuilder.InnerHtml.AppendHtml(this.BuildBall(ball.ToString(), BallColorViewModel.GetBallColor(ball)));
            });
            return tagBuilder.GetHtmlString();
        }

        private TagBuilder BuildBall(string choice, string cls)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"result-column result-text bacball-result " + cls);
            tagBuilder.InnerHtml.AppendHtml(choice);

            return tagBuilder;
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");

            var winningText = GetWinningOption(SettlementResult, stringLocalizer);
            tagBuilder.InnerHtml.AppendHtml(winningText);

            return tagBuilder.GetHtmlString();
        }

        public string GetWinningOption(SeBallSettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.InnerHtml.Append(GetText(stringLocalizer, settlementResult.Even ? "even" : "odd") + ", ");
            var subChoices = new List<string>() { "Blue4", "Blue3", "Red2", "Red3", "Red4" };
            var redCount = subChoices.FindIndex(choice => bool.Parse(settlementResult.GetType().GetProperty(choice).GetValue(settlementResult, null).ToString()));
            for (var i = 0; i < redCount; i++)
            {
                tagBuilder.InnerHtml.AppendHtml(SeBallHtmlHelper.RenderChip(true));
            }
            for (var j = 0; j < 4 - redCount; j++)
            {
                tagBuilder.InnerHtml.AppendHtml(SeBallHtmlHelper.RenderChip(false));
            }
            return tagBuilder.GetHtmlString();
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new TranslationBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "SeBall");
        }
    }
}