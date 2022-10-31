using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using GameRoundResult.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    [Collection("IntergrationTest")]
    public class IntegrationTestBase
    {
        protected readonly HttpClient TestClient;
        protected readonly IConfigurationRoot Config;
        protected string Domain;
        protected string ProjectDir = Directory.GetCurrentDirectory();

        protected IntegrationTestBase()
        {
            var configPath = Path.Combine(ProjectDir, "appsettings.IGT.json");
            var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(configPath);
                });
            });
            TestClient = appFactory.CreateClient();
            Config = new ConfigurationBuilder().AddJsonFile(configPath).Build();
            Domain = Config["HostConfiguration:Domain"];
        }

        protected const string OperatorId = "ONEworks1";
        protected const string OperatorSecret = "ONEworks1@20luminet&";

        protected string RemoveWhiteSpaces(string content)
        {
            var result = Regex.Replace(content, @"\s+", string.Empty);
            return Regex.Replace(result, @"\?v=(.*?)\""", "\"");
        }
    }
}