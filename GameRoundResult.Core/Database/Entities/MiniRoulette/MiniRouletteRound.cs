using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("roulette_phiens")]
    public class MiniRouletteRound : GameRound
    {
        public byte Result { get; set; }

        public MiniRouletteSettlementResult SettlementResult { get; set; }
    }

    public class MiniRouletteSettlementResult
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
