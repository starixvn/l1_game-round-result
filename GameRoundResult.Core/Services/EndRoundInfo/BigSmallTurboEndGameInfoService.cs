using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BigSmallTurboEndGameInfoService : BaseEndGameInfoService<TurboBigSmallRound, TurboBigSmallOne>, IEndGameInfoService
    {
        public BigSmallTurboEndGameInfoService(IMongoDatabase database)
            : base(database)
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
                ValidBetAmount = bet.Amount - bet.Refund,
                TotalAmount = bet.Amount,
                TotalWin = bet.Win ? bet.Betwin + bet.Amount : bet.Refund
            };
        }
    }
}