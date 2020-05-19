using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Models
{
    public class KenoProMaxRoundResultViewModel : RoundResultViewModel
    {
        public IEnumerable<byte> Result { get; set; }

        public bool IsEven { get; set; }

        public bool IsBig { get; set; }
    }
}