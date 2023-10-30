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
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"");
            tagBuilder.InnerHtml.AppendHtml("bandar result");          

            return tagBuilder.GetHtmlString();            
        }

        private TagBuilder BuildDice(string color)
        {
            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/{color}.png");

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