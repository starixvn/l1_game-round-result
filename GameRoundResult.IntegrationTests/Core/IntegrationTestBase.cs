using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using GameRoundResult.Web;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    [Collection("IntergrationTest")]
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly HttpClient TestDriver;
        protected string ProjectDir = Directory.GetCurrentDirectory();

        public IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
        {
            TestDriver = factory.CreateClient();
        }

        protected const string OperatorId = "ONEworks1";
        protected const string OperatorSecret = "ONEworks1@20luminet&";
        protected const string ResultServiceDomain = "http://localhost:7781/";

        protected string RemoveWhiteSpaces(string content)
        {
            var result = Regex.Replace(content, @"\s+", string.Empty);
            return Regex.Replace(result, @"\?v=(.*?)\""", "\"").Replace("</img>", string.Empty);
        }
    }
}