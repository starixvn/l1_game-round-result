using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("seball1_bets")]
    public class SeBall1Bet : GameDrawBaseBetEntity
    {
        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal Red2 { get; set; }
        public decimal Red3 { get; set; }
        public decimal Red4 { get; set; }
        public decimal Blue3 { get; set; }
        public decimal Blue4 { get; set; }

        public override decimal TotalBet => Odd + Even + Red2 + Red3 + Red4 + Blue3 + Blue4;
    }

    [CollectionName("sedienumber_bets")]
    public class SeDieNumberBet : SeBall1Bet { }

    [CollectionName("speedsedienumber_bets")]
    public class SpeedSeDieNumberBet : SeBall1Bet { }

    [CollectionName("vipsedienumber_bets")]
    public class VIPSeDieNumberBet : SeBall1Bet { }
}