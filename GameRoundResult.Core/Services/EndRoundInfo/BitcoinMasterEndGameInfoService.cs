using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BitcoinMasterEndGameInfoService : BaseEndGameInfoService<BitcoinMasterRound, BitcoinMasterOne>, IEndGameInfoService
    {
        private readonly IMongoCollection<BitcoinMasterBet> betLogCollection;

        public BitcoinMasterEndGameInfoService(IMongoDatabase database) : base(database)
        {
            betLogCollection = database.GetCollection<BitcoinMasterBet>(Document.GetCollectionName(typeof(BitcoinMasterBet)));
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);
            var betLogs = await GetBetLogsAsync(request);

            if (round == null || !betLogs.Any() || !bets.Any(x => x.Paid))
            {
                return EndGameInfoError.SB1001;
            }

            var amount = betLogs.Sum(x => x.Amount);
            var refund = betLogs.Sum(x => x.Refund);
            var totalWin = betLogs.Sum(x => x.Betwin > 0 ? x.Betwin + x.Amount : x.Refund);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = amount - refund,
                TotalAmount = amount,
                TotalWin = totalWin
            };
        }

        private async Task<IEnumerable<BitcoinMasterBet>> GetBetLogsAsync(RetrieveEndGameInfoRequest request)
        {
            return await betLogCollection.Find((bet) => bet.RoundId == request.GameRoundId
            && bet.PlayerId == request.PlayerId
            && bet.SiteId == request.SiteId
            && bet.OperatorId == request.OperatorId).ToListAsync();
        }
    }
}