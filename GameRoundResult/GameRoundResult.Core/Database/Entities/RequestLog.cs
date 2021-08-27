using System;
using GameRoundResult.Core.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class RequestLog
    {
        public RequestLog(DateTimeOffset requestTimeStamp, AccessUrlRequest request)
        {
            LogTimeStamp = DateTimeOffset.UtcNow;
            RequestTimeStamp = requestTimeStamp;
            AccessUrlRequest = request;
        }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset LogTimeStamp { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset RequestTimeStamp { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset ResponseTimeStamp { get; set; }

        public AccessUrlRequest AccessUrlRequest { get; set; }

        public AccessUrlResponse AccessUrlResponse { get; set; }
    }

    public class AccessUrlRequest
    {
        public GameType GameTypeId { get; set; }

        public AuthModel Auth { get; set; }

        public long GameRoundId { get; set; }

        public int ObCustId { get; set; }

        public string Language { get; set; }

        public bool FreeBet { get; set; }
    }

    public class AccessUrlResponse
    {
        public string RedirectUrl { get; set; }

        public string Error { get; set; }
    }

    public class AuthModel
    {
        public AuthModel(string clientId, string clientKey)
        {
            ClientID = clientId;
            ClientKey = clientKey;
        }

        public string ClientID { get; set; }

        public string ClientKey { get; set; }
    }
}