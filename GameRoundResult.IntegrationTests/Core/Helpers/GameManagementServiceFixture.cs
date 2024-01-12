using System;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace GameRoundResult.IntegrationTests.Core.Helpers
{
    [CollectionDefinition("Sequential")]
    public class GameManagementServiceCollection : ICollectionFixture<GameManagementServiceFixture>
    {
    }

    public class GameManagementServiceFixture : IDisposable
    {
        private readonly WireMockServer server;

        public GameManagementServiceFixture()
        {
            server = WireMockServer.Start("http://localhost:6789");
        }

        public void SetGameConfigApiResponse(int gameId, string gameName, GameConfigsType gameType)
        {
            var path = $"/game-configs/byid";
            server.Given(Request.Create().WithPath(path).WithParam("gameId", gameId.ToString()).UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/json")
                        .WithBodyAsJson(new { Data = new GameConfigModel { GameId = gameId, Name = gameName.ToLowerInvariant(), Type = gameType } })
                );
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            server.Stop();
        }

        ~GameManagementServiceFixture()
        {
            Dispose(false);
        }
    }
}
