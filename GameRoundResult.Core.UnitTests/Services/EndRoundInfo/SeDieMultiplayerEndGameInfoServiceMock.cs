using GameRoundResult.Core.Database.Entities.SeDieMultiplayer;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    internal class SeDieMultiplayerEndGameInfoServiceMock : SeDieMultiplayerEndGameInfoService
    {
        public SeDieMultiplayerRound Round { get; set; }
        public IEnumerable<SeDieMultiplayerBet> Bets { get; set; }

        public SeDieMultiplayerEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override Task<SeDieMultiplayerRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Round);

        protected override Task<IEnumerable<SeDieMultiplayerBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Bets);
    }
}
