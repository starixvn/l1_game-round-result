using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class ColorGameRoundResultViewModel : RoundResultViewModel
    {       
        public ColorGameResultViewModel Result { get; set; }

        public ColorGameSettlementResultViewModel SettlementResult { get; set; }

        public virtual bool IsWinningChoice(string choice)
        {
            return bool.Parse(SettlementResult.GetType().GetProperty(choice).GetValue(SettlementResult, null).ToString());
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetCardContent(Result)}",
               GetResultContent(stringLocalizer)
            };

            return result;
        }

        private static string GetCardContent(ColorGameResultViewModel result)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"");
            
            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/{"white"}.png");
            tagBuilder.InnerHtml.AppendHtml(img);

            return tagBuilder.GetHtmlString();
        }

        private string GetResultContent(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            List<string> result = new List<string> { };

            

            return string.Join(", ", result.ToArray());
        }

        

        private string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
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
    

    public class ColorGameSettlementResultViewModel
    {
        public bool Yellow { get; set; }

        public bool Red { get; set; }

        public bool Pink { get; set; }

        public bool White { get; set; }

        public bool Blue { get; set; }

        public bool Green { get; set; }

        public bool Hot { get; set; }

        public bool Cold { get; set; }
    }
}