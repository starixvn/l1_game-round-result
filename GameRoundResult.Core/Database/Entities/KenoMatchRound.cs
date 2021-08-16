using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoMatchRound : GameRound
    {
        public KenoMatchPeriod HalfTime { get; set; }
        public KenoMatchPeriod FullTime { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }

    public class KenoMatchPeriod
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Time { get; set; }

        [BsonElement("sum")]
        public int Total { get; set; }

        public KenoMatchPeriodResult Result { get; set; }

        public KenoMatchPeriodSettlementResult SettlementResult { get; set; }
    }

    public class KenoMatchPeriodResult
    {
        public List<int> Home { get; set; }
        public List<int> Away { get; set; }
    }

    public class KenoMatchPeriodSettlementResult
    {
        public bool Home { get; set; }
        public bool Away { get; set; }
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
    }

    [CollectionName("kenomatch1_phiens")]
    public class KenoMatch1Round: KenoMatchRound
    {

    }

    [CollectionName("kenomatch2_phiens")]
    public class KenoMatch2Round : KenoMatchRound
    {

    }
}