using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services.EndRoundInfo
{
    public class MiniRouletteEndGameInfoService : RouletteEndGameInfoService
    {
        public MiniRouletteEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
