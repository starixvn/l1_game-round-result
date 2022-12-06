using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GameRoundResult.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
        private readonly string ProjectDir = Directory.GetCurrentDirectory();

        private string databaseName;

        public DatabaseFixture()
        {
            ConnectToDatabase();
            ClearAllData();
            InsertOperators();
            InsertOtherGameDataStubs();
        }

        private void ConnectToDatabase()
        {
            var configPath = Path.Combine(ProjectDir, "appsettings.IGT.json");
            var config = new ConfigurationBuilder()
                .AddJsonFile(configPath, true, false)
                .Build();

            mongoClient = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            databaseName = config["DatabaseSettings:DatabaseName"];
            mongoDb = mongoClient.GetDatabase(databaseName);
        }

        public void Dispose()
        {
            ClearAllData();
        }

        private void ClearAllData()
        {
            mongoClient.DropDatabase(databaseName);
        }

        public IMongoDatabase mongoDb { get; private set; }

        public MongoClient mongoClient { get; private set; }

        private void InsertOtherGameDataStubs()
        {
            var directoryInfo = new DirectoryInfo($"{ProjectDir}/Games");
            var files = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.DirectoryName.EndsWith("DatabaseStubs"))
                {
                    var path = Path.Combine(file.DirectoryName, file.Name);
                    var doc = ReadFile(path);
                    var collectionName = Path.GetFileNameWithoutExtension(file.Name);
                    var collection = mongoDb.GetCollection<BsonDocument>(collectionName);
                    collection.InsertMany(doc);
                }
            }
        }

        private void InsertOperators()
        {
            var path = Path.Combine(ProjectDir, "Core/Stubs/partners.json");
            var doc = ReadFile(path);
            var collection = mongoDb.GetCollection<BsonDocument>("partners");
            collection.InsertMany(doc);
        }

        private IEnumerable<BsonDocument> ReadFile(string path)
        {
            string json = File.ReadAllText(path);
            return BsonSerializer.Deserialize<IEnumerable<BsonDocument>>(json);
        }
    }
}