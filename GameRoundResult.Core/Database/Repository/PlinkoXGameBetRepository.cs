using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IPlinkoXGameBetRepository : IPlinkoGameBetRepository
    {
    }

    public class PlinkoXGameBetRepository : GameBetRepository, IPlinkoXGameBetRepository
    {
        public PlinkoXGameBetRepository(IMongoDatabase database) : base(database)
        {
        }
        public async Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        {
            var round = (await GetPlinkoRoundAsync<PlinkoXGameRound>(roundId, playerId, CollectionNameFormatter.Round(gameName), operatorId));

            return round;
        }
    }
}
