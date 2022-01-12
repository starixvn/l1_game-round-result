using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("hilo_bets")]
    public class HiLoBet : BaseBetEntity
    {
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public int TotalTurns { get; set; }

        public IEnumerable<Card> Result { get; set; }

        public IEnumerable<string> SettlementResult { get; set; }
    }
}