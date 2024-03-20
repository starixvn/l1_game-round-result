using GameRoundResult.Core.Database.Entities.BacBall2;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BacBall2RoundResultViewModel : RoundResultViewModel
    {
        public long DrawId { get; set; }

        public BacBall2RoundResult Result { get; set; }

        public BacBall2SettlementResult SettlementResult { get; set; }        

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>()
            {
               base.ToDataTableArray(stringLocalizer).First(),
               DrawId.ToString(),
               $"{GetResult(stringLocalizer)}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("table");
            tagBuilder.AddCssClass($"result-table");
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(Result, stringLocalizer));

            return tagBuilder.GetHtmlString();            
        }      

        private TagBuilder BuildResultByChoice(BacBall2RoundResult result, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {                        

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");           
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(result.Player.ToString(), BacBall2ColorViewModel.GetBallColor(result.Player)));
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(result.Banker.ToString(), BacBall2ColorViewModel.GetBallColor(result.Banker)));


            return tagBuilder;
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

        public string GetWinningOption(BacBall2SettlementResult settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            string option = "";
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
            var betChoice = new BacBall2BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "BacBall");
        }        
    }    
}