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

        public List<string> InferableChoices = new List<string> { "hot", "cold" };

        public Dictionary<int, string> ResultMapper = new Dictionary<int, string>() { { 0, "yellow" }, { 1, "red" }, { 2, "pink" }, { 3, "white" }, { 4, "blue" }, { 5, "green" } };

        public virtual bool IsWinningChoice(string choice)
        {
            return SettlementResult[choice.ToLower()] > 0;            
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetResult()}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public string GetResult()
        {
            var tagBuilder = new TagBuilder("table");
            tagBuilder.AddCssClass($"result-table");
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice("Dealer"));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice("Spade")); 
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice("Heart"));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice("Club"));
            tagBuilder.InnerHtml.AppendHtml(this.BuildResultByChoice("Diamond"));

            return tagBuilder.GetHtmlString();            
        }

        private TagBuilder BuildResultByChoice(string choice)
        {
            var dominoTagBuilder = new TagBuilder("td");
            dominoTagBuilder.AddCssClass($"result-column");
            BandarQiuQiuResultItemViewModel item = (BandarQiuQiuResultItemViewModel)this.Result.GetType().GetProperty(choice).GetValue(this.Result, null);

            foreach(string domino in item.Dominoes)
            {
                dominoTagBuilder.InnerHtml.AppendHtml(this.BuildDice(domino));
            }

            var pipOfSetTagBuilder = new TagBuilder("td");
            pipOfSetTagBuilder.AddCssClass($"pip-of-set");
            pipOfSetTagBuilder.InnerHtml.AppendHtml(string.Format("{0}:{1}", item.PipsOfSet?.ToList()[0], item.PipsOfSet?.ToList()[1]));

            var tagBuilder = new TagBuilder("tr");
            tagBuilder.AddCssClass($"result-row");
            tagBuilder.InnerHtml.AppendHtml(this.BuildText(choice));
            tagBuilder.InnerHtml.AppendHtml(dominoTagBuilder);
            tagBuilder.InnerHtml.AppendHtml(pipOfSetTagBuilder);

            return tagBuilder;
        }

        private TagBuilder BuildText(string text)
        {
            var tagBuilder = new TagBuilder("td");
            tagBuilder.AddCssClass($"result-column");
            tagBuilder.InnerHtml.AppendHtml(text);

            return tagBuilder;
        }

        private TagBuilder BuildDice(string color)
        {
            var img = new TagBuilder("img");
            img.AddCssClass($"img domino-img");
            img.Attributes.Add("src", $"/scss/images/bandar-qiuqiu/{color}.png");

            return img;
        }

        public string GetWinningResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = GetResult();
            var inferableChoiceResult = new TagBuilder("span");
            inferableChoiceResult.AddCssClass($"color-game-inferable-result");
            foreach (KeyValuePair<string, int> entry in SettlementResult)
                                    {
                if (InferableChoices.Contains(entry.Key) && entry.Value > 0)
                {
                    inferableChoiceResult.InnerHtml.AppendHtml($" &#8212; {GetText(stringLocalizer, entry.Key)}");
                                            
                }
            }

            return $"{result}{inferableChoiceResult.GetHtmlString()}";
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

            return string.Join(", ", result);            
            
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            return stringLocalizer.GetStringWithNamcespace("glossary_" + key, "BandarQiuQiu");
        }        
    }

    public class BandarQiuQiuRoundResultModel
    {
        public BandarQiuQiuResultItemViewModel Dealer { get; set; }

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