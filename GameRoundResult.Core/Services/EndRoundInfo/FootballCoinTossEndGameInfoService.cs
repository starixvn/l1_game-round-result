using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class FootballCoinTossEndGameInfoService : BaseEndGameInfoService<FootballCoinTossRound, FootballCoinTossBet>, IEndGameInfoService
    {
        public FootballCoinTossEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);
            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.TotalBet);
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