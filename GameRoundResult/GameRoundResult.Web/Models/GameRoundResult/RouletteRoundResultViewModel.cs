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

        public RouletteSettlementResultViewModel SettlementResult { get; set; }
    }

    public class RouletteSettlementResultViewModel
    {
        public IEnumerable<string> StraightUp { get; set; }

        public IEnumerable<string> Split { get; set; }

        public IEnumerable<string> Street { get; set; }

        public IEnumerable<string> Triangle { get; set; }

        public IEnumerable<string> Corner { get; set; }

        public IEnumerable<string> FourNumbers { get; set; }

        public IEnumerable<string> Line { get; set; }

        public IEnumerable<string> Column { get; set; }

        public IEnumerable<string> Dozen { get; set; }

        public IEnumerable<string> RedBlack { get; set; }

        public IEnumerable<string> OddEven { get; set; }

        public IEnumerable<string> BigSmall { get; set; }
    }

}