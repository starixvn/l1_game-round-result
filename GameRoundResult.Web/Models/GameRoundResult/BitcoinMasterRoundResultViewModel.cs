using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class BitcoinMasterRoundResultViewModel : RoundResultViewModel
    {
        public Dictionary<string, bool> SettlementResult { get; set; }
        public BitcoinMasterRoundResult Result { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                Result.BettingPrice.Format(),
                GetResultContent(stringLocalizer),
                string.Join(", ",  GetWinningOptionsContent().Select(s => stringLocalizer[s]))
            };

            return result;
        }

        public string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"bitcoin-master-result");

            var span = new TagBuilder("span");
            span.InnerHtml.Append($"{Result.ResultPrice.Format()} ");
            tagBuilder.InnerHtml.AppendHtml(span);

            var amount = Result.ResultPrice - Result.BettingPrice;
            if (amount == 0)
            {
                return tagBuilder.GetHtmlString();
            }

            var direction = amount > 0 ? "up" : "down";
            span = new TagBuilder("span");
            span.AddCssClass(direction);
            span.InnerHtml.Append("(");

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/{direction}.png");
            span.InnerHtml.AppendHtml(img);

            var s2 = new TagBuilder("span");
            s2.AddCssClass("result-detail");
            s2.InnerHtml.Append($"{Math.Abs(amount).Format()})");
            span.InnerHtml.AppendHtml(s2);

            tagBuilder.InnerHtml.AppendHtml(span);

            return tagBuilder.GetHtmlString();
        }

        public IEnumerable<string> GetWinningOptionsContent()
        {
            var winningOptions = new List<string>
            {
                SettlementResult[BitcoinMasterBetChoice.Up] ? "Up" : string.Empty,
                SettlementResult[BitcoinMasterBetChoice.Down] ? "Down" : string.Empty,
                SettlementResult[BitcoinMasterBetChoice.Odd] ? "Odd" : string.Empty,
                SettlementResult[BitcoinMasterBetChoice.Even] ? "Even" : string.Empty
            };

            return winningOptions.Where(s => !string.IsNullOrWhiteSpace(s));
        }
    }
}