using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class ShakeThePlateRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<bool> RedChips { get; set; }

        public int TotalRed => RedChips.Count(x => x);

        public bool IsEven => TotalRed % 2 == 0;
    }
}