using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class VipFishPrawnCrabEndGameInfoService : BaseEndGameInfoService<VipFishPrawnCrabRound, VipFishPrawnCrabBet>, IEndGameInfoService
    {
        public VipFishPrawnCrabEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Stag + x.Rooster + x.Prawn + x.Gourd + x.Crab + x.Fish + x.AnyTriple + x.Mountain + x.Ocean);
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