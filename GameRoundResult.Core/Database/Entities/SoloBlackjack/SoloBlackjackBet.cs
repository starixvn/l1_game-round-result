using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("soloblackjack_bets")]
    public class SoloBlackjackBet : BaseBetEntity
    {
        [BsonElement("id")]
        public long HandId { get; set; }

        public byte Pos { get; set; }

        public IEnumerable<string> Actions { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public IEnumerable<byte> SoftPoints { get; set; }

        public byte Total { get; set; }

        public long? SplitFrom { get; set; }

        public decimal Bet { get; set; }
    }
}
