using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public interface ISoloBlackjackTicketService
    {
        Task<(SoloBlackjackRound, SoloBlackjackBet)> GetAsync(long handId, string playerId, string operatorId);
    }

    public class SoloBlackjackTicketService : ISoloBlackjackTicketService
    {
        private readonly ISoloBlackjackBetRepository repository;

        public SoloBlackjackTicketService(ISoloBlackjackBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(SoloBlackjackRound, SoloBlackjackBet)> GetAsync(long handId, string playerId, string operatorId)
        {
            return await repository.GetAsync(handId, playerId, operatorId);
        }
    }
}
