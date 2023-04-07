using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class Win3CardsEndGameInfoService : BaseEndGameInfoService<Win3CardsRound, Win3CardsBet>, IEndGameInfoService
    {
        public Win3CardsEndGameInfoService(IMongoDatabase database) : base(database)
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
            var amount = bet.Dragon + bet.Phoenix + bet.Pair8Plus + bet.Straight + bet.Flush + bet.StraightFlush + bet.ThreeOfAKind;

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount,
                TotalAmount = amount,
                TotalWin = bet.Betwin
            };
        }
    }
}