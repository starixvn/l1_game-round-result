using GameRoundResult.Core.Database.Entities.RNGSoccer;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class RNGSoccerEndGameInfoService : BaseEndGameInfoService<RNGSoccerRound, RNGSoccerBet>, IEndGameInfoService
    {
        public RNGSoccerEndGameInfoService(IMongoDatabase database) : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if(round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Home + x.Away + x.Draw);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin,
            };
        }

    }
}
