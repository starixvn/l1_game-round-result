using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IDrawBetRepository<Draw, Bets, BetLogs, Result, Settlement>
        where Draw : GameDraw<Result, Settlement>
        where Bets : GameDrawBaseBetEntity
        where BetLogs : GameDrawBaseBetEntity
    {
        Task<(Draw, Bets, IEnumerable<BetLogs>)> GetAsync(long drawId, string playerId, string operatorId);
    }

    public class DrawBetRepository<Draw, Bets, BetLogs, Result, Settlement> : GameBetRepository, IDrawBetRepository<Draw, Bets, BetLogs, Result, Settlement>
        where Draw : GameDraw<Result, Settlement>
        where Bets : GameDrawBaseBetEntity
        where BetLogs : GameDrawBaseBetEntity
        where Result : GameDrawBase
    {
        public DrawBetRepository(IMongoDatabase database) : base(database) { }

        public async Task<(Draw, Bets, IEnumerable<BetLogs>)> GetAsync(long drawId, string playerId, string operatorId)
        {
            var bet = await database.GetCollection<Bets>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            var betLogs = await database.GetCollection<BetLogs>()
                .Find(x => x.DrawId == drawId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .ToListAsync();

            var roundFilter = Builders<Draw>.Filter.ElemMatch(x => x.Result, y => y.DrawId == drawId);
            var round = await database.GetCollection<Draw>().Find(roundFilter).FirstOrDefaultAsync();

            return (round, bet, betLogs);
        }
    }
}
