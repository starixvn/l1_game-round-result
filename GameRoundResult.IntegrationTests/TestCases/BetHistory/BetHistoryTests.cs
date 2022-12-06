using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GameRoundResult.Core.Constants;
using GameRoundResult.IntegrationTests.Helpers;
using GameRoundResult.Web.Models;
using Newtonsoft.Json;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    public class BetHistoryTests : IntegrationTestBase
    {
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
        public async Task GetAccessUrl_ValidModel_ReturnRedirectUrl()
        {
            // arrange
            var model = GetBetHistoryAccessUrlRequestModel();

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result);
            Assert.StartsWith($"{ResultServiceDomain}en-US/BetHistory/", result.RedirectUrl);
        }

        #endregion GetAccessURL

        #region Index

        [Fact]
        public async Task Index_ValidData_RedirectIndexView()
        {
            // arrange
            const string expectedContentType = "text/html; charset=utf-8";
            var model = GetBetHistoryAccessUrlRequestModel();
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
            GameType gameType,
            int playerId,
            long roundId,
            string language,
            string fileName)
        {
            // arrange
            var model = GetBetHistoryAccessUrlRequestModel();
            model.GameTypeId = gameType;
            model.PlayerId = playerId;
            model.Language = language;
            model.GameRoundId = roundId;
            var url = await BuildAccessUrl(model);
            var expected = ReadTextFromFile(gameType, fileName);

            // act
            var response = await TestDriver.GetAsync(url);

            // assert
            Assert.Equal(expected, HttpUtility.HtmlDecode(RemoveWhiteSpaces(response.Content.ReadAsStringAsync().Result)));
        }

        #endregion Index

        #region Private Methods

        private string ReadTextFromFile(GameType game, string fileName)
        {
            var path = Path.Combine(ProjectDir, $"Games/{game}/Expected/BetHistory/{fileName}.html");
            return RemoveWhiteSpaces(File.ReadAllText(path));
        }

        private BetHistoryAccessUrlRequestModel GetBetHistoryAccessUrlRequestModel()
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