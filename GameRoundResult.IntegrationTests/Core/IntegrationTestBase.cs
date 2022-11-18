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
    public abstract class IntegrationTestBase
    {
        protected readonly HttpClient TestDriver;
        protected readonly IConfigurationRoot Config;
        protected string ResultServiceDomain;
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
            TestDriver = appFactory.CreateClient();
            Config = new ConfigurationBuilder().AddJsonFile(configPath).Build();
            ResultServiceDomain = Config["HostConfiguration:Domain"];
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