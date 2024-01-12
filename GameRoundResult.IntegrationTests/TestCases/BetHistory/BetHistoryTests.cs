using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GameRoundResult.Core.Constants;
using GameRoundResult.IntegrationTests.Core.Helpers;
using GameRoundResult.IntegrationTests.Helpers;
using GameRoundResult.Web;
using GameRoundResult.Web.Models;
using Newtonsoft.Json;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    public class BetHistoryTests : IntegrationTestBase
    {
        public BetHistoryTests(CustomWebApplicationFactory<Program> factory, GameManagementServiceFixture gameManagementServiceFixture) 
            : base(factory, gameManagementServiceFixture)
        {
            databaseHelper.ClearAllData();
        }

        #region GetAccessURL

        [Fact]
        public async Task GetAccessUrl_InvalidModel_BadRequest()
        {
            // arrange
            var model = new BetHistoryAccessUrlRequestModel
            {
                Auth = new AuthModel
                {
                    OperatorId = string.Empty,
                    OperatorSecret = string.Empty
                }
            };

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetAccessUrl_NotExistOperator_BadRequest()
        {
            // arrange
            var model = new BetHistoryAccessUrlRequestModel
            {
                Auth = new AuthModel
                {
                    OperatorId = string.Empty,
                    OperatorSecret = string.Empty
                },
                FreeBet = false,
                GameRoundId = 1,
                GameTypeId = GameType.BigSmall,
                Language = "en-US",
                PlayerId = 99
            };

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetAccessUrl_ValidModel_ReceiveSuccessCodeAndBetHistoryUrl()
        {
            // arrange
            var model = GetBetHistoryAccessUrlRequestModel();
            this.databaseHelper.InsertOperators();

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result);
            Assert.StartsWith($"{ResultServiceDomain}{model.Language}/BetHistory/", result.RedirectUrl);
        }

        #endregion GetAccessURL

        #region Index

        [Fact]
        public async Task Index_ValidData_RedirectIndexView()
        {
            // arrange
            const string expectedContentType = "text/html; charset=utf-8";
            var model = GetBetHistoryAccessUrlRequestModel();
            this.databaseHelper.InsertOperators();
            var url = await BuildAccessUrl(model);

            // act
            var response = await TestDriver.GetAsync(url);

            // assert
            Assert.Equal(expectedContentType, response.Content.Headers.ContentType.ToString());
            var indexView = (await HtmlHelpers.GetDocumentAsync(response)).Item1;
            Assert.NotNull(indexView.GetElementById("game-ticket"));
        }

        [Theory]
        [ClassData(typeof(BetHistoryTestCaseProvider))]
        public async Task Index_ValidData_RenderExpectedInfo(
            int gameId,
            string gameName,
            GameConfigsType gameType,
            string testcase,
            int playerId,
            long roundId,
            string language)
        {
            // arrange
            var model = GetBetHistoryAccessUrlRequestModel();
            model.GameTypeId = (GameType)gameId;
            model.PlayerId = playerId;
            model.Language = language;
            model.GameRoundId = roundId;
            databaseHelper.InsertCurrencyAndOperatorStub();
            databaseHelper.InsertDataGameStubs(gameName, "BetHistory", testcase);
            var url = await BuildAccessUrl(model);
            var expected = ReadTextFromFile(gameName, language, testcase);
            gameManagementService.SetGameConfigApiResponse(gameId, gameName, gameType);

            // act
            var response = await TestDriver.GetAsync(url);
            var result = HttpUtility.HtmlDecode(RemoveWhiteSpaces(response.Content.ReadAsStringAsync().Result));
            // assert
            Assert.Equal(expected, result);
        }

        #endregion Index

        #region Private Methods

        private string ReadTextFromFile(string game, string language, string testcase)
        {
            var path = Path.Combine(ProjectDir, $"Games/{game}/BetHistory/{testcase}/output.{language}.html");
            return RemoveWhiteSpaces(File.ReadAllText(path));
        }

        private static BetHistoryAccessUrlRequestModel GetBetHistoryAccessUrlRequestModel()
        {
            return new BetHistoryAccessUrlRequestModel
            {
                Auth = new AuthModel
                {
                    OperatorId = OperatorId,
                    OperatorSecret = OperatorSecret
                },
                FreeBet = false,
                GameRoundId = 1,
                GameTypeId = GameType.BigSmall,
                Language = "en-US",
                PlayerId = 123
            };
        }

        private async Task<HttpResponseMessage> SendRequestGetAccessURL(BetHistoryAccessUrlRequestModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await this.TestDriver.PostAsync("/BetHistory/GetAccessUrl", content);
            return response;
        }

        private async Task<string> BuildAccessUrl(BetHistoryAccessUrlRequestModel model)
        {
            var response = await SendRequestGetAccessURL(model);
            var redirectUrl = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result).RedirectUrl;
            var index = redirectUrl.IndexOf($"/{model.Language}/BetHistory/");
            return redirectUrl.Substring(index);
        }

        #endregion Private Methods
    }
}