using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class DragonTigerFightEndGameInfoService : BaseEndGameInfoService<DragonTigerFightRound, DragonTigerFightBet>, IEndGameInfoService
    {
        public DragonTigerFightEndGameInfoService(IMongoDatabase database) : base(database)
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

            var totalBetAmount = bets.Sum(x => x.Tiger + x.Dragon + x.Tie + x.BlackDragon + x.RedDragon + x.BlackTiger + x.RedTiger);
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