using System.Collections.Generic;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class VipFishPrawnCrabRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                GetDiceContent(),
            };

            return result;
        }

        private string GetDiceContent()
        {
            var result = new List<string>();

            foreach (var dice in Dices)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("vip-animal");
                tagBuilder.Attributes.Add("src", $"/scss/images/vip_animal_{dice}.png");

                result.Add(tagBuilder.GetHtmlString());
            }

            return string.Join("", result);
        }
    }
}