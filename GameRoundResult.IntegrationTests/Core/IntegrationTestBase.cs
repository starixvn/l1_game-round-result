using System.IO;
using System.Net.Http;
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

        public IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
        {
            TestDriver = factory.CreateClient();
            this.databaseHelper = factory.databaseHelper;
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