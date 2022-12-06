using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class FruitSlotEndGameInfoService : BaseEndGameInfoService<FruitSlotRound, FruitSlotBet>, IEndGameInfoService
    {
        public FruitSlotEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bet = (await GetBetsAsync(request)).FirstOrDefault();

            if (round == null || bet == null)
            {
                return EndRoundInfoError.SB1001;
            }

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