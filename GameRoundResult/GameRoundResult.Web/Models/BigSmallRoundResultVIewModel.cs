using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class BigSmallRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }

        public int Total => Dices.Sum(x => x);

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer));

            result.Add(GetDiceStringContent());
            result.Add(Total.ToString());

            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("bold");
            if (Total > 10)
            {
                tagBuilder.AddCssClass("text-red");
                tagBuilder.InnerHtml.Append(stringLocalizer["Big"]);
            }
            else
            {
                tagBuilder.AddCssClass("text-blue");
                tagBuilder.InnerHtml.Append(stringLocalizer["Small"]);
            }

            using var writer = new StringWriter();
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
            var htmlOutput = writer.ToString();
            result.Add(htmlOutput);

            return result;
        }

        private string GetDiceStringContent()
        {
            var result = new List<string>();

            foreach (var dice in Dices)
            {
                var tagBuilder = new TagBuilder("img");
                tagBuilder.AddCssClass("dice");
                tagBuilder.Attributes.Add("src", $"/scss/images/dice_{dice}.png");

                using var writer = new StringWriter();
                tagBuilder.WriteTo(writer, HtmlEncoder.Default);
                var htmlOutput = writer.ToString();
                result.Add(htmlOutput);
            }

            return string.Join("", result);
        }
    }
}