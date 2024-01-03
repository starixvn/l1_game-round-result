using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.Player
{
    public class SBLog
    {
        public SBLog(OperatorRequest request, SGResult result, DateTimeOffset requestTimeStamp, DateTimeOffset responseTimeStamp)
        {
            LogTimeStamp = DateTimeOffset.UtcNow;
            RequestTimeStamp = requestTimeStamp;
            Request = request;
            ResponseTimeStamp = responseTimeStamp;
            Result = result;
        }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset LogTimeStamp { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset RequestTimeStamp { get; set; }

        public OperatorRequest Request { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset ResponseTimeStamp { get; set; }

        public SGResult Result { get; set; }
    }
}