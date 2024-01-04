using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.IntegrationTests.Core.Helpers;
using GameRoundResult.Web;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using Newtonsoft.Json;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    public class RetrieveEndRoundTests : IntegrationTestBase
    {
        public RetrieveEndRoundTests(CustomWebApplicationFactory<Program> factory, GameManagementServiceFixture gameManagementServiceFixture) 
            : base(factory, gameManagementServiceFixture)
        {
        }

        #region Index

        [Theory]
        [ClassData(typeof(RetrieveEndRoundTestCaseProvider))]
        public async Task Index_ReturnExpectedInfo(
            int gameId,
            string gameName,
            GameConfigsType gameType,
            string testcase,
            string playerId,
            int roundId
            )
        {
            // arrange
            var model = GetModel();
            model.GameTypeId = (byte) gameId;
            model.PlayerId = playerId;
            model.GameRoundId = roundId;
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            databaseHelper.InsertCurrencyAndOperatorStub();
            databaseHelper.InsertDataGameStubs(gameName, "RetrieveEndRound", testcase);
            gameManagementService.SetGameConfigApiResponse(gameId, gameName, gameType);

            var expected = ReadTextFromFile(gameName, testcase);

            // act
            var response = await this.TestDriver.PostAsync("/EndRoundInfo", content);
            var actual = JsonConvert.DeserializeObject<EndRoundInfoResult>(response.Content.ReadAsStringAsync().Result);

            // assert
            Assert.Equal(expected.TotalAmount, actual.TotalAmount);
            Assert.Equal(expected.TotalWin, actual.TotalWin);
            Assert.Equal(expected.ValidBetAmount, actual.ValidBetAmount);
            Assert.Equal(expected.EndTime, actual.EndTime);
            Assert.Equal(expected.ErrorCode, actual.ErrorCode);
            Assert.Equal(expected.ErrorDescription, actual.ErrorDescription);
        }

        #endregion Index

        #region Private Methods

        private EndRoundInfoResult ReadTextFromFile(string game, string testcase)
        {
            var path = Path.Combine(ProjectDir, $"Games/{game}/RetrieveEndRound/{testcase}/output.json");
            return JsonConvert.DeserializeObject<EndRoundInfoResult>(File.ReadAllText(path));
        }

        private static RetrieveEndRoundInfoRequest GetModel()
        {
            return new RetrieveEndRoundInfoRequest
            {
                Auth = new AuthModel
                {
                    OperatorId = OperatorId,
                    OperatorSecret = OperatorSecret
                },
                FreeBet = false,
                GameRoundId = 1,
                GameTypeId = (byte)GameType.BigSmall,
                PlayerId = "123",
                SiteId = "4100300"
            };
        }

        #endregion Private Methods
    }
}