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
    public interface IPlinkoXGameBetRepository
    {
        Task<PlinkoXGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class PlinkoXGameBetRepository : GameBetRepository, IPlinkoXGameBetRepository
    {
        public PlinkoXGameBetRepository(IMongoDatabase database) : base(database)
        {
        }
        public async Task<PlinkoXGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        {
            var round = await database
                .GetCollection<PlinkoXGameRound>(CollectionNameFormatter.Round(gameName))
                .Find(x => x.RoundId == roundId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .FirstOrDefaultAsync();

            return round;
        }
    }
}
