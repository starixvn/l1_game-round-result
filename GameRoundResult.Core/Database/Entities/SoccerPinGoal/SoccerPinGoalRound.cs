using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("soccerpingoal_rounds")]
    public class SoccerPinGoalRound : GameRound
    {
        public SoccerPinGoalResultEntity Result { get; set; }

        public SoccerPinGoalSettlementResultEntity SettlementResult { get; set; }
    }

    public class SoccerPinGoalResultEntity
    {
        public int Red { get; set; }

        public int Blue { get; set; }

        public int RedTunnel { get; set; }

        public int BlueTunnel { get; set; }
    }

    public class SoccerPinGoalSettlementResultEntity
    {
        public bool Red { get; set; }

        public bool Blue { get; set; }

        public bool Draw { get; set; }
    }
}
