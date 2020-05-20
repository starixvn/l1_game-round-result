using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class KenoProMaxRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Result { get; set; }

        public int Total => Result.Sum(x => x);

        public bool IsEven { get; set; }

        public bool IsBig { get; set; }

        public bool IsEarth { get; set; }

        public bool IsFire { get; set; }

        public bool IsWood { get; set; }

        public bool IsWater { get; set; }

        public bool IsGold { get; set; }
    }
}