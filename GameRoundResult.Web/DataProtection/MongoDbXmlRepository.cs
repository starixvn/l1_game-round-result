using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GameRoundResult.Web.DataProtection
{
    public class MongoDbXmlRepository : IXmlRepository
    {
        private readonly IMongoCollection<KeyElement> collection;
        private readonly string appName;

        public MongoDbXmlRepository(IMongoDatabase database, string collectionName, string appName)
        {
            collection = database.GetCollection<KeyElement>(collectionName);
            this.appName = appName;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            var keyElements = collection.Find(x => x.AppName == appName).ToList();
            return keyElements.Select(element => XElement.Parse(element.Xml)).ToList().AsReadOnly();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            var keyElement = new KeyElement
            {
                AppName = appName,
                Xml = element.ToString(SaveOptions.DisableFormatting)
            };
            collection.InsertOne(keyElement);
        }
    }

    public class KeyElement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string AppName { get; set; }

        public string Xml { get; set; }
    }
}