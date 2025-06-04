using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("roulettes_rounds")]
    public class RouletteSRound : GameRound
    {
        public byte Result { get; set; }

        public RouletteSSettlementResult SettlementResult { get; set; }
    }

    public class RouletteSSettlementResult : RouletteSettlementResult
    {
    }
}
