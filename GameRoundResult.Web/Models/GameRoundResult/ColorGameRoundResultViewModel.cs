using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class ColorGameRoundResultViewModel : RoundResultViewModel
    {       
        public ColorGameResultViewModel Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }

        public List<string> InferableChoices = new List<string> { "hot", "cold" };

        public virtual bool IsWinningChoice(string choice)
        {
            return SettlementResult[choice.ToLower()];            
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
            var resultMapper = new Dictionary<int, string>() { { 0, "yellow"}, { 1, "red"}, { 2, "pink"}, { 3, "white" }, { 4, "blue" }, { 5, "green" } };
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"");
            tagBuilder.InnerHtml.AppendHtml(BuildDice(resultMapper[Result.Dice1]));
            tagBuilder.InnerHtml.AppendHtml(BuildDice(resultMapper[Result.Dice2]));
            tagBuilder.InnerHtml.AppendHtml(BuildDice(resultMapper[Result.Dice3]));

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
            foreach (KeyValuePair<string, bool> entry in SettlementResult)
                                    {
                if (InferableChoices.Contains(entry.Key) && entry.Value)
                {
                    inferableChoiceResult.InnerHtml.AppendHtml($" &#8212; {GetText(stringLocalizer, entry.Key)}");
                                            
                }
            }

            return $"{result}{inferableChoiceResult.GetHtmlString()}";
        }

        public string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            foreach (KeyValuePair<string, bool> entry in SettlementResult)
            {
                if (entry.Value)
                {
                    result.Add(GetText(stringLocalizer, entry.Key));
                }
            }

            return string.Join(", ", result);            
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            return stringLocalizer.GetStringWithNamcespace("glossary_" + key, "ColorGame");
        }        
    }

    public class ColorGameResultViewModel
    {
        public byte Dice1 { get; set; }

        public byte Dice2 { get; set; }

        public byte Dice3 { get; set; }
    }   
}