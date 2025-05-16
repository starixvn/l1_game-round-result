using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinMining
{

    [CollectionName("coinmining_rounds")]
    public class CoinMiningRound : BaseCrashTurnRoundEntity
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string OperatorName { get; set; }

    }
}
