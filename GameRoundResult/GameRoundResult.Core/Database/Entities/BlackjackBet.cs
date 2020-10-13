using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BlackjackBet : BaseBetEntity
    {
        [BsonElement("id")]
        public long HandId { get; set; }

        public byte Pos { get; set; }

        public IEnumerable<string> Actions { get; set; }

        public IEnumerable<BlackjackCard> Cards { get; set; }

        public byte Total { get; set; }

        public long? SplitFrom { get; set; }

        public decimal Bet { get; set; }
    }
}