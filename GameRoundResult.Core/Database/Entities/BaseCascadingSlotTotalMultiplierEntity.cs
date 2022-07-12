namespace GameRoundResult.Core.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;

    public class BaseCascadingSlotTotalMultiplierEntity : Document
    {
        public int PlayerId { get; set; }

        public bool Ended { get; set; }

        public IEnumerable<BaseCascadingSlotRoundMultiplier> Rounds { get; set; }
    }

    public class BaseCascadingSlotRoundMultiplier
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Time { get; set; }

        public long RoundId { get; set; }

        public byte TotalMultiplier { get; set; }

        public byte Multiplier { get; set; }
    }
}
