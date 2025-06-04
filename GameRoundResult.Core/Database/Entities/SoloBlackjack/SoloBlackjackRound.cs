using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("soloblackjack_rounds")]
    public class SoloBlackjackRound : GameRound
    {
        public IEnumerable<Card> Result { get; set; }

        public DateTime RoundStartTime { get; set; }

        public bool Ended { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public byte SettlementResult { get; set; }
    }
}
