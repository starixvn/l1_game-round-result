using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class RouletteRoundResultViewModel : RoundResultViewModel
    {
        public byte Result { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               Result.ToString()
            };

            return result;
        }
    }
}