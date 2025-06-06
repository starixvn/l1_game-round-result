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
    public class MiniRouletteEndGameInfoServiceMock : MiniRouletteEndGameInfoService
    {
        public MiniRouletteRound Round { get; set; }
        public IEnumerable<MiniRouletteBet> Bets { get; set; }

        public MiniRouletteEndGameInfoServiceMock(IMongoDatabase database) : base(database)
        {
        }

        protected override Task<MiniRouletteRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Round);

        protected override Task<IEnumerable<MiniRouletteBet>> GetBetsAsync(RetrieveEndGameInfoRequest request)
            => Task.FromResult(Bets);
    }
}
