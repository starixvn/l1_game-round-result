using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("seball1_betlogs")]
    public class SeBall1BetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }

    [CollectionName("sedienumber_betlogs")]
    public class SeDieNumberBetLog : SeBall1BetLog { }

    [CollectionName("speedsedienumber_betlogs")]
    public class SpeedSeDieNumberBetLog : SeBall1BetLog { }

    [CollectionName("vipsedienumber_betlogs")]
    public class VIPSeDieNumberBetLog : SeBall1BetLog { }

}