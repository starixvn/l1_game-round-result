using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Database.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public interface IDrawTicketService<Draw, Bets, BetLogs, Result, Settlement>
     where Draw : GameDraw<Result, Settlement>
     where Bets : GameDrawBaseBetEntity
     where BetLogs : GameDrawBaseBetEntity
     where Result : GameDrawResultBase
    {
        Task<(Draw, Bets, IEnumerable<BetLogs>)> GetAsync(long drawId, string playerId, string operatorId);
    }

    public class DrawTicketService<Draw, Bets, BetLogs, Result, Settlement> : IDrawTicketService<Draw, Bets, BetLogs, Result, Settlement>
        where Draw : GameDraw<Result, Settlement>
        where Bets : GameDrawBaseBetEntity
        where BetLogs : GameDrawBaseBetEntity
        where Result : GameDrawResultBase
    {
        private readonly IDrawBetRepository<Draw, Bets, BetLogs, Result, Settlement> repository;

        public DrawTicketService(IDrawBetRepository<Draw, Bets, BetLogs, Result, Settlement> repository)
        {
            this.repository = repository;
        }

        public async Task<(Draw, Bets, IEnumerable<BetLogs>)> GetAsync(long drawId, string playerId, string operatorId)
        {
            return await repository.GetAsync(drawId, playerId, operatorId);
        }
    }
}
