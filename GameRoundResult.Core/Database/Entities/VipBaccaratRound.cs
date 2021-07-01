namespace GameRoundResult.Core.Database.Entities
{
    public class VipBaccaratRound : GameRound
    {
        public VipBaccaratResult Result { get; set; }

        public BaccaratResult SettlementResult { get; set; }
    }

    public class VipBaccaratResult
    {
        public Side Player { get; set; }

        public Side Banker { get; set; }
    }
}
