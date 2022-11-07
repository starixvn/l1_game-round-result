using System.Collections.Generic;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class FanTanRoundResultViewModel : RoundResultViewModel
    {
        public FanTanResultViewModel Result { get; set; }

        public FanTanSettlementResultViewModel SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetResultString(),
                stringLocalizer[GetFanWinChoice()],
                stringLocalizer[GetOddEvenWinChoice()],
                GetKwokWinChoice(stringLocalizer),
                GetChunWinChoice(stringLocalizer)
            };

            return result;
        }

        private string GetResultString()
        {
            var span = new TagBuilder("span");
            span.AddCssClass("bold");
            span.AddCssClass("result-" + Result.FinalBeads);
            span.InnerHtml.Append(string.Empty);

            return span.GetHtmlString();
        }

        private string GetFanWinChoice()
        {
            if (SettlementResult.Fan1)
            {
                return "Fan1";
            }

            if (SettlementResult.Fan2)
            {
                return "Fan2";
            }

            if (SettlementResult.Fan3)
            {
                return "Fan3";
            }

            return "Fan4";
        }

        private string GetOddEvenWinChoice()
        {
            if (SettlementResult.Odd)
            {
                return "Odd";
            }

            return "Even";
        }

        private string GetKwokWinChoice(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();

            if (SettlementResult.Kwok12)
            {
                result.Add(stringLocalizer["Kwok12"]);
            }

            if (SettlementResult.Kwok23)
            {
                result.Add(stringLocalizer["Kwok23"]);
            }

            if (SettlementResult.Kwok34)
            {
                result.Add(stringLocalizer["Kwok34"]);
            }

            if (SettlementResult.Kwok41)
            {
                result.Add(stringLocalizer["Kwok41"]);
            }

            return string.Join(",<br />", result);
        }

        private string GetChunWinChoice(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();

            if (SettlementResult.Chun123)
            {
                result.Add(stringLocalizer["Chun123"]);
            }

            if (SettlementResult.Chun124)
            {
                result.Add(stringLocalizer["Chun124"]);
            }

            if (SettlementResult.Chun134)
            {
                result.Add(stringLocalizer["Chun134"]);
            }

            if (SettlementResult.Chun234)
            {
                result.Add(stringLocalizer["Chun234"]);
            }

            return string.Join(",<br />", result);
        }
    }

    public class FanTanResultViewModel
    {
        public byte TotalBeads { get; set; }
        public byte FinalBeads { get; set; }
    }

    public class FanTanSettlementResultViewModel
    {
        public bool Odd { get; set; }
        public bool Even { get; set; }

        public bool Fan1 { get; set; }
        public bool Fan2 { get; set; }
        public bool Fan3 { get; set; }
        public bool Fan4 { get; set; }

        public bool Kwok12 { get; set; }
        public bool Kwok23 { get; set; }
        public bool Kwok34 { get; set; }
        public bool Kwok41 { get; set; }

        public bool Chun123 { get; set; }
        public bool Chun124 { get; set; }
        public bool Chun134 { get; set; }
        public bool Chun234 { get; set; }
    }

}