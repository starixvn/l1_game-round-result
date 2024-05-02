using System.Collections.Generic;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("seball1_rounds")]
    public class SeBall1Round : GameDraw<SeBallRoundResult, SeBallSettlementResult>
    {
    }

    public class SeBallRoundResult : GameDrawResultBase
    {
        public List<int> Balls { get; set; }
    }

    public class SeBallSettlementResult : GameDrawBase
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool Red2 { get; set; }
        public bool Red3 { get; set; }
        public bool Red4 { get; set; }
        public bool Blue3 { get; set; }
        public bool Blue4 { get; set; }
    }
}