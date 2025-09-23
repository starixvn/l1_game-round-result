using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class BaccaratMultiplayerEndGameInfoServiceMock : BaccaratMultiplayerEndGameInfoService
    {
        public BaccaratMultiplayerRound Round { get; set; }
        public IEnumerable<BaccaratMultiplayerBet> Bets { get; set; }

        public BaccaratMultiplayerEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override Task<BaccaratMultiplayerRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Round);

        protected override Task<IEnumerable<BaccaratMultiplayerBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Bets);
    }
}
