using System;
using GameRoundResult.Web.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace GameRoundResult.IntegrationTests
{
    [CollectionDefinition("Sequential")]
    public class GameAdminApiCollection : ICollectionFixture<GameAdminApiFixture>
    {
    }

    public class GameAdminApiFixture : IDisposable
    {
        private readonly WireMockServer server;

        public GameAdminApiFixture()
        {
            server = WireMockServer.Start("http://localhost:7778");
        }

        public void SetGameConfigApiResponse(int gameId, string gameName)
        {
            server.Given(Request.Create().WithPath($"/api/public/game_configs/{gameId}").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/json")
                        .WithBodyAsJson(new GameConfigModel { GameId = gameId, Name = gameName.ToLowerInvariant() })
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

        ~GameAdminApiFixture()
        {
            Dispose(false);
        }
    }
}