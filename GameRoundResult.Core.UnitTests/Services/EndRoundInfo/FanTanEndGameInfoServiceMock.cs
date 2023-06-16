using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using MongoDB.Driver;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class FanTanEndGameInfoServiceMock : FanTanEndGameInfoService
    {
        public FanTanRound Round { get; set; }
        public IEnumerable<FanTanBet> Bets { get; set; }

        public FanTanEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override Task<FanTanRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Round);

        protected override Task<IEnumerable<FanTanBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Bets);
    }
}
