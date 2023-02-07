using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using GameRoundResult.Web;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    [Collection("Sequential")]
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly HttpClient TestDriver;
        protected string ProjectDir = Directory.GetCurrentDirectory();
        protected readonly DatabaseHelper databaseHelper;
        protected readonly GameAdminApiFixture gameAdminApi;

        public IntegrationTestBase(CustomWebApplicationFactory<Program> factory, GameAdminApiFixture gameAdminApiFixture)
        {
            TestDriver = factory.CreateClient();
            TestDriver.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
            this.databaseHelper = factory.databaseHelper;
            this.gameAdminApi = gameAdminApiFixture;
        }

        protected const string OperatorId = "ONEworks1";
        protected const string OperatorSecret = "ONEworks1@20luminet&";
        protected const string ResultServiceDomain = "http://localhost:7781/";

        protected static string RemoveWhiteSpaces(string content)
        {
            var result = Regex.Replace(content, @"\s+", string.Empty);
            return Regex.Replace(result, @"\?v=(.*?)\""", "\"").Replace("</img>", string.Empty);
        }
    }
}