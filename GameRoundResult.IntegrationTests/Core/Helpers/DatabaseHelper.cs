using System;
using System.Collections.Generic;
using System.IO;
using GameRoundResult.Core.Constants;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class DatabaseHelper : IDisposable
    {
        private readonly string ProjectDir = Directory.GetCurrentDirectory();

        private string databaseName;

        public DatabaseHelper()
        {
            ConnectToDatabase();
            ClearAllData();
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            ClearAllData();
        }

        ~DatabaseHelper()
        {
            Dispose(false);
        }

        public void ClearAllData()
        {
            mongoClient.DropDatabase(databaseName);
        }

        public IMongoDatabase mongoDb { get; private set; }

        public MongoClient mongoClient { get; private set; }

        public void InsertOperators()
        {
            var collectionName = "partners";
            var path = Path.Combine(ProjectDir, $"Core/Stubs/{collectionName}.json");
            string json = File.ReadAllText(path);
            InsertData(collectionName, json);
        }

        public void InsertCurrencyAndOperatorStub()
        {
            var directoryInfo = new DirectoryInfo($"{ProjectDir}/Core/Stubs");
            var files = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var path = Path.Combine(file.DirectoryName, file.Name);
                string json = File.ReadAllText(path);
                var collectionName = Path.GetFileNameWithoutExtension(file.Name);
                InsertData(collectionName, json);
            }
        }

        public void InsertDataGameStubs(GameType game, string featureName, string folderName)
        {
            var directoryInfo = new DirectoryInfo($"{ProjectDir}/Games/{game}/{featureName}");
            var files = directoryInfo.GetFiles("input.json", SearchOption.AllDirectories);
            var subpath = Path.Combine(game.ToString(), featureName, folderName);
            foreach (var file in files)
            {
                if (file.DirectoryName.Contains(subpath))
                {
                    var path = Path.Combine(file.DirectoryName, file.Name);
                    string json = File.ReadAllText(path);
                    var test = JObject.Parse(json);
                    foreach (var property in test.Properties())
                    {
                        var collectionName = Path.GetFileNameWithoutExtension(property.Name);
                        InsertData(collectionName, property.Value.ToString());
                    }
                }
            }
        }

        private void InsertData(string collectionName, string json)
        {
            mongoDb.DropCollection(collectionName);
            var doc = BsonSerializer.Deserialize<IEnumerable<BsonDocument>>(json);
            var collection = mongoDb.GetCollection<BsonDocument>(collectionName);
            collection.InsertMany(doc);
        }
    }
}