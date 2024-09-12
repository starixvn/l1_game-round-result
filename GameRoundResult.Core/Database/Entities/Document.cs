using System;
using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Time { get; set; }

        public static string GetCollectionName(Type documentType)
        {
            return ((CollectionNameAttribute)Attribute.GetCustomAttribute(documentType, typeof(CollectionNameAttribute)))?.CollectionName;
        }
    }
}