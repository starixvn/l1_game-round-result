using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISoloBlackjackBetRepository
    {
        Task<(SoloBlackjackRound, SoloBlackjackBet)> GetAsync(long handId, string playerId, string operatorId);
    }
    public class SoloBlackjackBetRepository : GameBetRepository, ISoloBlackjackBetRepository
    {
        public SoloBlackjackBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(SoloBlackjackRound, SoloBlackjackBet)> GetAsync(long handId, string playerId, string operatorId)
        {
            var bet = await database.GetCollection<SoloBlackjackBet>(Document.GetCollectionName(typeof(SoloBlackjackBet)))
                .Find(x => x.HandId == handId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<SoloBlackjackRound>(bet.RoundId, Document.GetCollectionName(typeof(SoloBlackjackRound)));

                return (round, bet);
            }

            return (null, bet);
        }
    }
}
