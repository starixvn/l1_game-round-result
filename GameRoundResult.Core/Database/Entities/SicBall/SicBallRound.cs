using System.Collections.Generic;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sicball_rounds")]
    public class SicBallRound : GameDraw<SicBallRoundResult, SicBallSettlementResult>
    {
    }

    public class SicBallRoundResult : GameDrawResultBase
    {
        public List<int> Balls { get; set; }
    }

    public class SicBallSettlementResult : GameDrawBase
    {
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Specific1 { get; set; }
        public bool Specific2 { get; set; }
        public bool Specific3 { get; set; }
        public bool Specific4 { get; set; }
        public bool Specific5 { get; set; }
        public bool Specific6 { get; set; }
    }

    [CollectionName("sicbonumber_rounds")]
    public class SicBoNumberRound : SicBallRound { }

    [CollectionName("speedsicbonumber_rounds")]
    public class SpeedSicBoNumberRound : SicBallRound { }

    [CollectionName("vipsicbonumber_rounds")]
    public class VIPSicBoNumberRound : SicBallRound { }

}