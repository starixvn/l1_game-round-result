using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.CoinMining
{

    [CollectionName("goldanddragon_rounds")]
    public class GoldAndDragonRound : BaseCascadingClusterRoundEntity
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string OperatorName { get; set; }

        public decimal Amount { get; set; }

        public long DrawId { get; set; }

    }
}
