namespace GameRoundResult.Web.Models
{
    public class DragonTigerFightRoundResultViewModel : RoundResultViewModel
    {
        public DragonTigerFightResultViewModel Result { get; set; }

        public DragonTigerFightSettlementResultViewModel SettlementResult { get; set; }
    }

    public class DragonTigerFightResultViewModel
    {
        public DragonTigerFightCard Dragon { get; set; }

        public DragonTigerFightCard Tiger { get; set; }
    }

    public class DragonTigerFightCard
    {
        public byte Card { get; set; }

        public byte Type { get; set; }
    }

    public class DragonTigerFightSettlementResultViewModel
    {
        public bool Dragon { get; set; }

        public bool Tiger { get; set; }

        public bool Tie { get; set; }

        public bool BlackDragon { get; set; }

        public bool RedDragon { get; set; }

        public bool BlackTiger { get; set; }

        public bool RedTiger { get; set; }
    }
}