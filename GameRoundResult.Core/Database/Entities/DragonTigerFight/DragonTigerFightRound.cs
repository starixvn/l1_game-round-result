using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.DragonTigerFight
{
    [CollectionName("dragontigerfight_rounds")]
    public class DragonTigerFightRound : GameRound
    {
        public DragonTigerFightResult Result { get; set; }

        public DragonTigerFightSettlementResult SettlementResult { get; set; }
    }

    public class DragonTigerFightResult
    {
        public DragonTigerCard Dragon { get; set; }

        public DragonTigerCard Tiger { get; set; }
    }

    public class DragonTigerFightSettlementResult
    {
        public bool Dragon { get; set; }

        public bool Tiger { get; set; }

        public bool Tie { get; set; }

        public bool BlackDragon { get; set; }

        public bool RedDragon { get; set; }

        public bool BlackTiger { get; set; }

        public bool RedTiger { get; set; }
    }
    
    public class DragonTigerCard
    {
        public byte Card { get; set; }

        public byte Type { get; set; }
    }
}
