using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class BaseDrawResultViewModel<TResult, TSettlementResutl> : RoundResultViewModel
        where TResult : GameDrawResultBase
        where TSettlementResutl : GameDrawBase
    {
        public long DrawId { get; set; }

        public TResult Result { get; set; }

        public TSettlementResutl SettlementResult { get; set; }

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

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"result-row");

            var winningText = GetWinningOption(SettlementResult, stringLocalizer);
            tagBuilder.InnerHtml.AppendHtml(winningText);

            return tagBuilder.GetHtmlString();
        }

        public virtual string GetWinningOption(TSettlementResutl settlementResult, IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return "";
        }
    }
}