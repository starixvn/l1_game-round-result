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
            result.AppendLine(GetFirstRowResult(stringLocalizer));
            result.AppendLine(GetSecondRowResult(stringLocalizer));
            result.AppendLine(GetThirdRowResult(stringLocalizer));

            return result.ToString();
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
                result.Append(SettlementResult[VipSeDieWarBetChoice.Banker] ? stringLocalizer["Banker"] : stringLocalizer["Tie"]);
            }

            result.Append(SettlementResult[VipSeDieWarBetChoice.Odd] ? $", {stringLocalizer["TotalOdd"]}" : $", {stringLocalizer["TotalEven"]}");

            return result.ToString();
        }

        private string GetSecondRowResult(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new StringBuilder();

            result.Append(SettlementResult[VipSeDieWarBetChoice.PlayerEven] ? stringLocalizer["PlayerEven"] : stringLocalizer["PlayerOdd"]);

            result.Append(SettlementResult[VipSeDieWarBetChoice.Banker] ? $", {stringLocalizer["BankerEven"]}" : $", {stringLocalizer["BankerOdd"]}");

            return result.ToString();
        }

        private string GetThirdRowResult(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            var playerResult = new StringBuilder();
            var bankerResult = new StringBuilder();

            if (SettlementResult[VipSeDieWarBetChoice.PlayerRed3])
            {
                result.Add(stringLocalizer["PlayerRed3"]);
            }
            else
            {
                if (SettlementResult[VipSeDieWarBetChoice.PlayerRed4])
                {
                    result.Add(stringLocalizer["PlayerRed3"]);
                }

                if (SettlementResult[VipSeDieWarBetChoice.PlayerWhite3])
                {
                    result.Add(stringLocalizer["PlayerRed1"]);
                }

                if (SettlementResult[VipSeDieWarBetChoice.PlayerWhite4])
                {
                    result.Add(stringLocalizer["PlayerWhite4"]);
                }
            }

            if (SettlementResult[VipSeDieWarBetChoice.BankerRed3])
            {
                result.Add(stringLocalizer["BankerRed3"]);
            }
            else
            {
                if (SettlementResult[VipSeDieWarBetChoice.BankerRed4])
                {
                    result.Add(stringLocalizer["BankerRed4"]);
                }

                if (SettlementResult[VipSeDieWarBetChoice.BankerWhite3])
                {
                    result.Add(stringLocalizer["BankerRed1"]);
                }

                if (SettlementResult[VipSeDieWarBetChoice.BankerWhite4])
                {
                    result.Add(stringLocalizer["BankerWhite4"]);
                }
            }

            return string.Join(", ", result);
        }
    }
}