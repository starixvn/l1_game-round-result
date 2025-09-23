using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.SevenUpDown;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BaccaratMultiplayerEndGameInfoService : BaseEndGameInfoService<BaccaratMultiplayerRound, BaccaratMultiplayerBet>, IEndGameInfoService
    {
        public BaccaratMultiplayerEndGameInfoService(IMongoDatabase database) : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);
            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Player + x.Banker + x.AnyPair + x.Tie);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }
    }
}
