using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("roulette_cuocs")]
    public class MiniRouletteBetLog : BaseBetLogEntity
    {
        public Dictionary<string, decimal> StraightUp { get; set; }

        public Dictionary<string, decimal> Split { get; set; }

        public Dictionary<string, decimal> Street { get; set; }

        public Dictionary<string, decimal> Triangle { get; set; }

        public Dictionary<string, decimal> Corner { get; set; }

        public Dictionary<string, decimal> FourNumbers { get; set; }

        public Dictionary<string, decimal> Line { get; set; }

        public Dictionary<string, decimal> Column { get; set; }

        public Dictionary<string, decimal> Dozen { get; set; }

        public Dictionary<string, decimal> RedBlack { get; set; }

        public Dictionary<string, decimal> OddEven { get; set; }

        public Dictionary<string, decimal> BigSmall { get; set; }
    }
}
