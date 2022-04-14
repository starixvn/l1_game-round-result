using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("treasureisland_rounds")]
    public class TreasureIslandRound : GameRound
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }

        public decimal BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public List<byte[]> Boards { get; set; }

        public List<double> TumbleWins { get; set; }

        public List<int> TumbleMultipliers { get; set; }

        public List<Dictionary<int, double>> WinningIcons { get; set; }

        public List<Dictionary<int, double>> WinningAmounts { get; set; }
    }
}