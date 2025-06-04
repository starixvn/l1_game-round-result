using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services.EndRoundInfo
{
    public class RouletteSEndGameInfoService : RouletteEndGameInfoService
    {
        public RouletteSEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
