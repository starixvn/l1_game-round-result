using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using Newtonsoft.Json;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    public class EndRoundInfoTests : IntegrationTestBase
    {
        public EndRoundInfoTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        #region Index

        [Theory]
        [ClassData(typeof(EndRoundTestCaseProvider))]
        public async Task Index_ReturnExpectedInfo(
            GameType game,
            int playerId,
            int roundId,
            decimal totalAmount,
            decimal totalWin,
            decimal validBet,
            DateTimeOffset? endTime,
            string errorCode,
            string errorDescription
            )
        {
            // arrange
            var model = GetModel();
            model.GameTypeId = (byte)game;
            model.PlayerId = playerId;
            model.GameRoundId = roundId;
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            databaseHelper.InsertDataGameStubs(game, "EndRound", $"{roundId}_");

            // act
            var response = await this.TestDriver.PostAsync("/EndRoundInfo", content);
            var actual = JsonConvert.DeserializeObject<EndRoundInfoResult>(response.Content.ReadAsStringAsync().Result);

            // assert
            Assert.Equal(totalAmount, actual.TotalAmount);
            Assert.Equal(totalWin, actual.TotalWin);
            Assert.Equal(validBet, actual.ValidBetAmount);
            Assert.Equal(endTime, actual.EndTime);
            Assert.Equal(errorCode, actual.ErrorCode);
            Assert.Equal(errorDescription, actual.ErrorDescription);
        }

        #endregion Index

        #region Private Methods

        private RetrieveEndRoundInfoRequest GetModel()
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
                PlayerId = 123,
                SiteId = "4100300"
            };
        }

        #endregion Private Methods
    }
}