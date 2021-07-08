using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoSoccerRound : GameRound
    {
        public KenoSoccerPeriod HalfTime { get; set; }
        public KenoSoccerPeriod FullTime { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }

    public class KenoSoccerPeriod
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Time { get; set; }

        [BsonElement("sum")]
        public int Total { get; set; }

        public KenoSoccerPeriodResult Result { get; set; }
    }

    public class KenoSoccerPeriodResult
    {
        public List<int> Home { get; set; }
        public List<int> Away { get; set; }
    }

    public class KenoSoccerPeriodSettlementResult
    {
        public bool Home { get; set; }
        public bool Away { get; set; }
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
    }

    [CollectionName("MyDinh_phiens")]
    public class KenoSoccerMyDinhRound: KenoSoccerRound
    {

    }
}