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
    public interface IPlinkoGameBetRepository
    {
        Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class PlinkoGameBetRepository : GameBetRepository, IPlinkoGameBetRepository
    {
        public PlinkoGameBetRepository(IMongoDatabase database) : base(database)
        {
        }
        public async Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        {
            var round = (await GetPlinkoRoundAsync<PlinkoGameRound>(roundId, playerId, CollectionNameFormatter.Round(gameName), operatorId));

            return round;
        }
    }
}
