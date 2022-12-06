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
using AngleSharp.Html.Dom;

namespace GameRoundResult.IntegrationTests
{
    public class GameRoundResultTests : IntegrationTestBase
    {
        #region GetAccessURL

        [Fact]
        public async Task GetAccessUrl_NotExistClientAndOperator_BadRequest()
        {
            // arrange
            var model = new GameRoundResultAccessUrlRequestModel
            {
                Auth = new GameRoundResultAuthModel
                {
                    OperatorId = string.Empty,
                    OperatorSecret = string.Empty,
                    ClientID = string.Empty,
                    ClientKey = string.Empty
                }
            };

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetAccessUrl_ExistOperator_ReturnRedirectUrl()
        {
            // arrange
            var model = new GameRoundResultAccessUrlRequestModel
            {
                Auth = new GameRoundResultAuthModel
                {
                    OperatorId = OperatorId,
                    OperatorSecret = OperatorSecret
                },
            };

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result);
            Assert.NotNull(result.RedirectUrl);
            Assert.NotEmpty(result.RedirectUrl);
            Assert.StartsWith($"{ResultServiceDomain}vi-VN/GameRoundResult/Auth/", result.RedirectUrl);
        }

        [Fact]
        public async Task GetAccessUrl_ExistClient_ReturnRedirectUrl()
        {
            // arrange
            var model = GetRoundResultAccessUrlRequestModel();

            // act
            var response = await SendRequestGetAccessURL(model);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result);
            Assert.StartsWith($"{ResultServiceDomain}en-US/GameRoundResult/Auth/", result.RedirectUrl);
        }

        #endregion GetAccessURL

        #region Index

        [Fact]
        public async Task Index_ValidData_RedirectIndexView()
        {
            // arrange
            const string expectedContentType = "text/html; charset=utf-8";
            var model = GetRoundResultAccessUrlRequestModel();
            var url = await BuildAccessUrl(model);

            // act
            var response = await TestDriver.GetAsync(url);

            // assert
            Assert.Equal(expectedContentType, response.Content.Headers.ContentType.ToString());
            var indexView = (await HtmlHelpers.GetDocumentAsync(response)).Item1;
            Assert.NotNull(indexView.GetElementById("round-result"));
        }

        [Theory]
        [ClassData(typeof(RoundResultSelectOptionsTestCaseProvider))]
        public async Task Index_ExistGameOption(GameType game, string gameName, string language)
        {
            // arrange
            var model = GetRoundResultAccessUrlRequestModel();
            model.Language = language;
            var url = await BuildAccessUrl(model);

            // act
            var response = await TestDriver.GetAsync(url);
            var indexView = (await HtmlHelpers.GetDocumentAsync(response)).Item1;
            var options = (IHtmlOptionElement)indexView.QuerySelector($"option[value={((byte)game)}]");

            // assert
            Assert.NotNull(options);
            Assert.Equal(gameName, options.Text);
        }

        #endregion Index

        #region GetData

        [Theory]
        [ClassData(typeof(RoundResultTestCaseProvider))]
        public async Task GetData_ValidData_ReturnExpectedInfo(
            GameType game,
            int roundId,
            string date,
            string language,
            string fileName
            )
        {
            // arrange
            var expected = ReadTextFromFile(game, fileName);
            var model = GetRoundResultAccessUrlRequestModel(language);
            var url = await BuildAccessUrl(model);
            await TestDriver.GetAsync(url);
            var gameId = (int)game;

            // act
            var response = await TestDriver.GetAsync($"{language}/GameRoundResult/GetData?gameType={gameId}&roundId={roundId}&date={date}");
            // assert
            var result = RemoveWhiteSpaces(JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result).ToString());
            Assert.Equal(expected, HttpUtility.HtmlDecode(result));
        }

        #endregion GetData

        #region Private Methods

        private string ReadTextFromFile(GameType game, string fileName)
        {
            var path = Path.Combine(ProjectDir, $"Games/{game}/Expected/RoundResult/{fileName}.json");
            return RemoveWhiteSpaces(File.ReadAllText(path));
        }

        private GameRoundResultAccessUrlRequestModel GetRoundResultAccessUrlRequestModel(string language = "")
        {
            return new GameRoundResultAccessUrlRequestModel
            {
                Auth = new GameRoundResultAuthModel
                {
                    ClientID = "Game Admin 2",
                    ClientKey = "a3d39c90-df4e-4225-bf66-5fbecbdedc06"
                },
                Language = string.IsNullOrEmpty(language) ? "en-US" : language,
            };
        }

        private async Task<HttpResponseMessage> SendRequestGetAccessURL(GameRoundResultAccessUrlRequestModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await this.TestDriver.PostAsync("/GameRoundResult/GetAccessUrl", content);
            return response;
        }

        private async Task<string> BuildAccessUrl(GameRoundResultAccessUrlRequestModel model)
        {
            var response = await SendRequestGetAccessURL(model);
            var redirectUrl = JsonConvert.DeserializeObject<GameTicketAccessUrlResultModel>(response.Content.ReadAsStringAsync().Result).RedirectUrl;
            var index = redirectUrl.IndexOf($"/{model.Language}");
            return redirectUrl.Substring(index);
        }

        #endregion Private Methods
    }
}