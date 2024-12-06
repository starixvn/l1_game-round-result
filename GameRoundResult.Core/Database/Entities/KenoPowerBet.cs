using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoPowerBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }

    [CollectionName("kenopower1_cuocs")]
    public class KenoPower1Bet : KenoPowerBet
    {
    }

    [CollectionName("kenopower2_cuocs")]
    public class KenoPower2Bet : KenoPowerBet
    {
    }

    [CollectionName("kenopower_betlogs")]
    public class SKKenoPowerBetLog : KenoPowerBet
    {
    }

    [CollectionName("kenopower2_betlogs")]
    public class SKKenoPower2BetLog : KenoPowerBet
    {
    }
}