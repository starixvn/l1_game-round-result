using System.Collections.Generic;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marbles158_bets")]
    public class Marbles158Bet : RoundHistoryBetEntity
    {
        public Dictionary<int, Marbles158BetChoice> BetAmount { get; set; }
        public Dictionary<int, Dictionary<string, Marbles158BetOdds>> MarbleOdds { get; set; }
    }

    public class Marbles158BetOdds {
        public decimal Price { get; set; }
        public decimal Point { get; set; }
    }

    public class Marbles158BetChoice
    {
        public decimal Home { get; set; }

        public decimal Away { get; set; }

        public decimal Draw { get; set; }

        public decimal Over { get; set; }

        public decimal Under { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }
    }
}
