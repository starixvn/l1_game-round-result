using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FishPrawnRoundResultVIewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Dices { get; set; }
    }
}