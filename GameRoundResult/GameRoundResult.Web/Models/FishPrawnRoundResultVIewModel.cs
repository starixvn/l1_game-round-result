using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FishPrawnRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }
    }
}