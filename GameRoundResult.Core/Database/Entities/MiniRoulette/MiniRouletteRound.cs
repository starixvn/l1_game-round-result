using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("miniroulette_rounds")]
    public class MiniRouletteRound : GameRound
    {
        public byte Result { get; set; }

        public MiniRouletteSettlementResult SettlementResult { get; set; }
    }

    public class MiniRouletteSettlementResult : RouletteSettlementResult
    {

    }
}
