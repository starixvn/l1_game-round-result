using System.Collections.Generic;
using System.Text;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieWarRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> PlayerChips { get; set; }
        public IEnumerable<bool> BankerChips { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }

        public bool IsEven { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetChipContent(PlayerChips),
                GetChipContent(BankerChips),
                GetResultContent(stringLocalizer)
            };

            return result;
        }

        private string GetChipContent(IEnumerable<bool> chips)
        {
            var result = new List<string>();

            foreach (var chip in chips)
            {
                var tagBuilder = new TagBuilder("i");

                tagBuilder.AddCssClass(chip ? "red-chip" : "white-chip");

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }

        private string GetResultContent(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("br");
            var result = new StringBuilder();
            result.Append(GetFirstRowResult(stringLocalizer));
            result.AppendLine();

            return tagBuilder.GetHtmlString();
        }

        private string GetFirstRowResult(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new StringBuilder();

            if (SettlementResult[VipSeDieWarBetChoice.Player])
            {
                result.Append(stringLocalizer["Player"]);
            }
            else
            {
                if (SettlementResult[VipSeDieWarBetChoice.Banker])
                {
                    result.Append(stringLocalizer["Banker"]);
                }
                else
                {
                    result.Append(stringLocalizer["Tie"]);
                }
            }

            result.Append(SettlementResult[VipSeDieWarBetChoice.Odd] ? $", {stringLocalizer["TotalOdd"]}" : $", {stringLocalizer["TotalEven"]}");

            return result.ToString();
        }
    }
}