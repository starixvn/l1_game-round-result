using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class CrashGameBetLog : BaseBetLogEntity
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Amount { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal WinAmount { get; set; }

        public decimal Multiplier { get; set; }

        public string Action { get; set; }

        public bool ReachMaxWin { get; set; }

        public byte BetKey { get; set; }
    }

    [CollectionName("spaceflight_betlogs")]
    public class SpaceFlightBetLog: CrashGameBetLog
    {

    }
}
