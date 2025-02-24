using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinMining
{

    [CollectionName("coinmining_rounds")]
    public class CoinMiningRound : BaseCrashTurnBetEntity
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string OperatorName { get; set; }

        public decimal Amount { get; set; }
    }
}
