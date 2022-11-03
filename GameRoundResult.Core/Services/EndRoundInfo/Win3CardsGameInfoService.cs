using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    class Win3CardsGameInfoService : BaseEndGameInfoService<Win3CardsRound, Win3CardsBet>, IEndGameInfoService
    {
        public Win3CardsGameInfoService(IMongoDatabase database) : base(database)
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
