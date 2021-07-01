using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class RNGKenoBet : Document
    {
        [BsonElement("phien")]
        public long Round { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}
