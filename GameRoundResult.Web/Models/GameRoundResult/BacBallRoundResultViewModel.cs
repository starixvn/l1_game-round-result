using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BacBallRoundResultViewModel : RoundResultViewModel
    {       

        public List<BacBallRoundResult> Result { get; set; }

        public List<BacBallSettlementResult> SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetResult(stringLocalizer)}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("table");
            tagBuilder.AddCssClass($"result-table");
            foreach(var result in Result)
            {
                tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(result, stringLocalizer));
            }
            return tagBuilder.GetHtmlString();            
        }      

        private TagBuilder BuildResultByChoice(BacBallRoundResult result, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {                        

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");           
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(result.Player.ToString(), "player"));
            tagBuilder.InnerHtml.AppendHtml(this.BuildBall(result.Banker.ToString(), "banker"));


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

            foreach (var settlementResult in SettlementResult.Select((value, i) => new { i, value })) {
                var winningText = this.GetWinningOption(settlementResult.value, settlementResult.i, stringLocalizer);
                var contentBuilder = new TagBuilder("div");
                contentBuilder.AddCssClass($"result-row");
                contentBuilder.InnerHtml.AppendHtml(winningText);
                tagBuilder.InnerHtml.AppendHtml(contentBuilder);
            }

            return tagBuilder.GetHtmlString();
        }

        public string GetWinningOption(BacBallSettlementResult settlementResult, int index, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            string option = "";
            if (settlementResult.Player)
            {
                option = this.GetText(stringLocalizer, "player");
            }
            else if (settlementResult.Banker)
            {
                option = this.GetText(stringLocalizer, "banker");
            }
            else
            {
                option = this.GetText(stringLocalizer, "tie");
            }

            var order = index switch
            {
                0 => "1st",
                1 => "2nd",
                2 => "3rd",
                3 => "4th",
                _ => ""
            };


            return string.Format("{0}: {1}", order, option);
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BacBallBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "BacBall");
        }        
    }    
}