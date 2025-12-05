using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class Marbles158EndGameInfoService
        : BaseEndGameInfoService<Marbles158Round, Marbles158Bet>,
            IEndGameInfoService
    {
        public Marbles158EndGameInfoService(IMongoDatabase database)
            : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var marbles158Round = await GetRoundAsync(request);
            var marbles158Bets = await GetBetsAsync(request);

            if (marbles158Round == null || !marbles158Bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = marbles158Bets.Sum(x => x.TotalAmount);
            var totalBetWin = marbles158Bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = marbles158Round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin,
            };
        }
    }
}
