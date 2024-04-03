using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRoundResult.Web.Models
{
    public class LuckyNextRoundResultViewModel : RoundResultViewModel
    {
        public long DrawId { get; set; }

        public LuckyNextRoundResult Result { get; set; }

        public LuckyNextSettlementResult SettlementResult { get; set; }

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

        public string GetResult()
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(Result.Ball.ToString(), BallColorViewModel.GetBallColor(Result.Ball)));

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

        public string GetWinningOption(LuckyNextSettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            StringBuilder sb = new StringBuilder();
            
            if (settlementResult.Over)
            {
                sb.Append(GetText(stringLocalizer, "over"));
            }
            if (settlementResult.Under)
            {
                sb.Append(GetText(stringLocalizer, "under"));
            }

            sb.Append(", ");

            if (settlementResult.Odd)
            {
                sb.Append(GetText(stringLocalizer, "odd"));
            }
            if (settlementResult.Even)
            {
                sb.Append(GetText(stringLocalizer, "even"));
            }

            return sb.ToString();
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new TranslationBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "LuckyNext");
        }
    }
}