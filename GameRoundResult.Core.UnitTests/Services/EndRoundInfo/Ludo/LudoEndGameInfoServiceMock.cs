using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Core.Services;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class LudoEndGameInfoServiceMock : LudoEndGameInfoService
    {
        public LudoRound Round { get; set; }
        public IEnumerable<LudoBet> Bets { get; set; }

        public LudoEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override Task<LudoRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Round);

        protected override Task<IEnumerable<LudoBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Bets);
    }
}
