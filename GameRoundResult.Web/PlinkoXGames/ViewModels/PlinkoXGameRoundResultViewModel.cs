using GameRoundResult.Web.Configuration;
using System.Collections.Generic;
using GameRoundResult.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Core.Constants;
using System.Globalization;
using System;
using GameRoundResult.Core.Database.Entities;

namespace GameRoundResult.Web.PlinkoXGames.ViewModels
{
    public class PlinkoXGameRoundResultViewModel : RoundResultViewModel
    {
        public PlinkoXSettlement SettlementResult { get; set; }

        public string DisplayResult => $"{SettlementResult.Multiplier}x";

        public decimal WinAmount { get; set; }
        public bool ReachMaxWin { get; set; }

        public string DisplayWinAmount => WinAmount.Format();
        public string DisplayWinLoss => (WinAmount - Amount).Format();

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public string DisplayAmount => Amount.Format();

        public decimal ConvertToBase(decimal amount, int baseCurrencyMultiplier)
        {
            var result = amount * Rate / baseCurrencyMultiplier;

            return result;
        }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               GetResultContent(),
            };

            return result;
        }

        private string GetResultContent()
        {
            var tagBuilder = new TagBuilder("span");

            tagBuilder.AddCssClass("bold");
            var span = new TagBuilder("span");
            span.InnerHtml.Append(SettlementResult.Multiplier + "x");

            tagBuilder.InnerHtml.AppendHtml(span);
            return tagBuilder.GetHtmlString();
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return DisplayResult;
        }
    }
}
