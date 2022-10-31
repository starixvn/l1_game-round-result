using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GameRoundResult.IntegrationTests
{
    public class DbFixture : IDisposable
    {
        public DbFixture()
        {
            var configPath = Path.Combine(ProjectDir, "appsettings.IGT.json");
            var config = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            mongoClient = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            databaseName = config["DatabaseSettings:DatabaseName"];
            this.clearAllData();
            mongoDb = mongoClient.GetDatabase(databaseName);
            InsertDB();
        }

        public void Dispose()
        {
            this.clearAllData();
        }

        private void clearAllData()
        {
            mongoClient.DropDatabase(databaseName);
        }

        private readonly string ProjectDir = Directory.GetCurrentDirectory();

        private string databaseName { get; }
        public IMongoDatabase mongoDb { get; }
        public MongoClient mongoClient { get; }

        public void InsertDB()
        {
            InsertOperators();
            var directoryInfo = new DirectoryInfo($"{ProjectDir}/Games");
            var files = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.DirectoryName.EndsWith("Data"))
                {
                    var path = Path.Combine(file.DirectoryName, file.Name);
                    var doc = ReadFile(path);
                    var collectionName = Path.GetFileNameWithoutExtension(file.Name);
                    var collection = mongoDb.GetCollection<BsonDocument>(collectionName);
                    collection.InsertMany(doc);
                }
            }
        }

        public void InsertOperators()
        {
            var path = Path.Combine(ProjectDir, $"Core/StubData/partners.json");
            var doc = ReadFile(path);
            var collection = mongoDb.GetCollection<BsonDocument>("partners");
            collection.InsertMany(doc);
        }

        public IEnumerable<BsonDocument> ReadFile(string path)
        {
            string json = File.ReadAllText(path);
            return BsonSerializer.Deserialize<IEnumerable<BsonDocument>>(json);
        }
    }
}