using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using GameRoundResult.IntegrationTests.Core.Helpers;
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
        protected readonly GameManagementServiceFixture gameManagementService;

        public IntegrationTestBase(CustomWebApplicationFactory<Program> factory, GameManagementServiceFixture gameManagementServiceFixture)
        {
            TestDriver = factory.CreateClient();
            TestDriver.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
            this.databaseHelper = factory.databaseHelper;
            this.gameManagementService = gameManagementServiceFixture;
        }

        protected const string OperatorId = "ONEworks1";
        protected const string OperatorSecret = "ONEworks1@20luminet&";
        protected const string ResultServiceDomain = "http://localhost:7781/";

        protected static string RemoveWhiteSpaces(string content)
        {
            var result = Regex.Replace(content, @"\s+", string.Empty);
            result = Regex.Replace(result, @"<!DOCTYPEhtml>", string.Empty);
            result = Regex.Replace(result, "<htmllang=\"en\">", string.Empty);
            result = Regex.Replace(result, "<head>.*?</head>", string.Empty);
            result = Regex.Replace(result, @"<br>(?![/])", "<br/>");
            result = Regex.Replace(result, "<tbody><trclass=\"result-row\">", "<trclass=\"result-row\">");
            result = Regex.Replace(result, "</tbody></table>", "</table>");
            result = Regex.Replace(result, "<inputtype=\"hidden\"value=\"en-US\"id=\"culture\">", "<inputtype=\"hidden\"value=\"en-US\"id=\"culture\"/>");

            return Regex.Replace(result, @"\?v=(.*?)\""", "\"").Replace("</img>", string.Empty);
        }
    }
}