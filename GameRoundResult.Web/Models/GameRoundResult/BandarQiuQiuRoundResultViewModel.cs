using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BandarQiuQiuRoundResultViewModel : RoundResultViewModel
    {       
        public BandarQiuQiuRoundResultModel Result { get; set; }

        public Dictionary<string, int> SettlementResult { get; set; }

        private readonly string Banker = "banker";
        private readonly string Spade = "spade";
        private readonly string Heart = "heart";
        private readonly string Club = "club";
        private readonly string Diamond = "diamond";
        public Dictionary<int, string> ResultMapper = new Dictionary<int, string>() { { 0, "hand_ranking_ordinary" }, { 1, "hand_ranking_qiuqiu" }, { 2, "hand_ranking_big" }, { 3, "hand_ranking_small" }, { 4, "hand_ranking_twin" }, { 5, "hand_ranking_six_devil" } };

        public virtual bool IsWinOrTieChoice(string choice)
        {            
            return SettlementResult[choice.ToLower()] > 0;            
        }

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
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(this.Banker, stringLocalizer));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(this.Spade, stringLocalizer)); 
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(this.Heart, stringLocalizer));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(this.Club, stringLocalizer));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice(this.Diamond, stringLocalizer));

            return tagBuilder.GetHtmlString();            
        }

        private TagBuilder BuildResultByChoice(string choice, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var betChoice = new BandarQiuQiuBetLogViewModel { Choice = choice };
            var dominoTagBuilder = new TagBuilder("td");
            dominoTagBuilder.AddCssClass($"result-column domino-column");
            BandarQiuQiuResultItemViewModel item = (BandarQiuQiuResultItemViewModel)this.Result.GetType().GetProperty(betChoice.ChoiceDisplay).GetValue(this.Result, null);

            foreach(string domino in item.Dominoes)
            {
                dominoTagBuilder.InnerHtml.AppendHtml(this.BuildDice(domino));
            }

            var pipOfSetTagBuilder = new TagBuilder("td");
            pipOfSetTagBuilder.AddCssClass($"result-column pip-of-set-column");
            if (item.HandRankingId == 0) {
                pipOfSetTagBuilder.InnerHtml.AppendHtml(string.Format("{0}:{1}", item.PipsOfSet?.ToList()[0], item.PipsOfSet?.ToList()[1]));
            }
            else
            {
                pipOfSetTagBuilder.InnerHtml.AppendHtml(string.Format("{0}", GetText(stringLocalizer, ResultMapper[item.HandRankingId])));
            }            

            var tagBuilder = new TagBuilder("tr");
            tagBuilder.AddCssClass($"result-row");
            if(choice != this.Banker && SettlementResult[choice] == 1)
            {
                tagBuilder.AddCssClass("bold");
            }
            tagBuilder.InnerHtml.AppendHtml(this.BuildText(choice, stringLocalizer));
            tagBuilder.InnerHtml.AppendHtml(dominoTagBuilder);
            tagBuilder.InnerHtml.AppendHtml(pipOfSetTagBuilder);

            return tagBuilder;
        }

        private TagBuilder BuildText(string choice, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("td");
            tagBuilder.AddCssClass($"result-column result-text");
            tagBuilder.InnerHtml.AppendHtml(GetText(stringLocalizer, choice));

            return tagBuilder;
        }

        private TagBuilder BuildDice(string color)
        {
            var img = new TagBuilder("img");
            img.AddCssClass($"img domino-img");
            img.Attributes.Add("src", $"/scss/images/bandar-qiuqiu/{color}.png");

            return img;
        }      

        public string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            foreach (KeyValuePair<string, int> entry in SettlementResult)
            {
                if (entry.Value > 0)
                {
                    result.Add(GetText(stringLocalizer, entry.Key));
                }
            }

            return result.Count > 0 ? string.Join(", ", result) : "-"; ;
            
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BandarQiuQiuBetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.TolgeeChoiceKey, "BandarQiuQiu");
        }        
    }

    public class BandarQiuQiuRoundResultModel
    {
        public BandarQiuQiuResultItemViewModel Banker { get; set; }

        public BandarQiuQiuResultItemViewModel Spade { get; set; }

        public BandarQiuQiuResultItemViewModel Heart { get; set; }

        public BandarQiuQiuResultItemViewModel Club { get; set; }

        public BandarQiuQiuResultItemViewModel Diamond { get; set; }
    }

    public class BandarQiuQiuResultItemViewModel
    {
        public List<string> Dominoes { get; set; }

        public int HandRankingId { get; set; }

        public IEnumerable<int> PipsOfSet { get; set; }
    }
}