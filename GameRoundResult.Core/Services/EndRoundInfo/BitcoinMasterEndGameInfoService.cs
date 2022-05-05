using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BitcoinMasterEndGameInfoService : BaseEndGameInfoService<BitcoinMasterRound, BitcoinMasterOne>, IEndGameInfoService
    {
        public BitcoinMasterEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndGameInfoError.SB1001;
            }

            var amount = bets.Sum(x => x.TotalAmount);
            var refund = bets.Sum(x => x.Refund);
            var totalWin = bets.Sum(x => x.Betwin > 0 ? x.Betwin + x.TotalAmount : x.Refund);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount - refund,
                TotalAmount = amount,
                TotalWin = totalWin
            };
        }
    }
}