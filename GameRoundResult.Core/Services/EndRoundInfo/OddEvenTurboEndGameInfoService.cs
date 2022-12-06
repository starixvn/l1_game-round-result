using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class OddEvenTurboEndGameInfoService : BaseEndGameInfoService<TurboOddEvenRound, OddEvenOne>, IEndGameInfoService
    {
        public OddEvenTurboEndGameInfoService(IMongoDatabase database) : base(database)
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

            var bet = bets.FirstOrDefault();
            var betAmount = bet.Amount;

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = betAmount - bet.Refund,
                TotalAmount = betAmount,
                TotalWin = bet.Win ? bet.Betwin + betAmount : bet.Refund
            };
        }
    }
}