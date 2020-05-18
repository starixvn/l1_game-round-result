using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BigSmallRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }

        public int Total => Dices.Sum(x => x);
    }
}