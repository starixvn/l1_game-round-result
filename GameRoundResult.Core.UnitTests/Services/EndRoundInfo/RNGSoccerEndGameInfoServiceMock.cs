using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Database.Entities.RNGSoccer;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    class RNGSoccerEndGameInfoServiceMock : RNGSoccerEndGameInfoService
    {
        public RNGSoccerRound Round { get; set; }
        public IEnumerable<RNGSoccerBet> Bets { get; set; }

        public RNGSoccerEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override async Task<RNGSoccerRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Round;

        protected override async Task<IEnumerable<RNGSoccerBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Bets;
    }
}
