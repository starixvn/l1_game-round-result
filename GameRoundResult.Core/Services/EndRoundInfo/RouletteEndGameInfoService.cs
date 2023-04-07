using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class RouletteEndGameInfoService : BaseEndGameInfoService<RouletteRound, RouletteOne>, IEndGameInfoService
    {
        public RouletteEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request, string gameName)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var bet = bets.FirstOrDefault();

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = bet.TotalAmount,
                TotalAmount = bet.TotalAmount,
                TotalWin = bet.Betwin
            };
        }
    }
}