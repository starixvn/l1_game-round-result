using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("currencies")]
    public class Currency : Document
    {
        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        public string PartnerId { get; set; }
    }
}