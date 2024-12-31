using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sicball_bets")]
    public class SicBallBet : GameDrawBaseBetEntity
    {
        public decimal Big { get; set; }
        public decimal Small { get; set; }
        public decimal Specific1 { get; set; }
        public decimal Specific2 { get; set; }
        public decimal Specific3 { get; set; }
        public decimal Specific4 { get; set; }
        public decimal Specific5 { get; set; }
        public decimal Specific6 { get; set; }
        public override decimal TotalBet => Big + Small + Specific1 + Specific2 + Specific3 + Specific4 + Specific5 + Specific6;
    }

    [CollectionName("sicbonumber_bets")]
    public class SicBoNumberBet : SicBallBet { }

    [CollectionName("speedsicbonumber_bets")]
    public class SpeedSicBoNumberBet : SicBallBet { }

    [CollectionName("vipsicbonumber_bets")]
    public class VIPSicBoNumberBet : SicBallBet { }

}