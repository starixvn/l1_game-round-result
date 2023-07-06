using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    class DragonTigerFightEndGameInfoServiceMock : DragonTigerFightEndGameInfoService
    {
        public DragonTigerFightRound Round { get; set; }
        public IEnumerable<DragonTigerFightOne> Bets { get; set; }

        public DragonTigerFightEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override async Task<DragonTigerFightRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Round;

        protected override async Task<IEnumerable<DragonTigerFightOne>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Bets;
    }
}
