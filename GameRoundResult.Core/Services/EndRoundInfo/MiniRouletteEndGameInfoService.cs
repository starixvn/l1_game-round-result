using Amazon.Runtime.Internal.Transform;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class MiniRouletteEndGameInfoService : BaseEndGameInfoService<MiniRouletteRound, MiniRouletteBet>, IEndGameInfoService
    {
        public MiniRouletteEndGameInfoService(IMongoDatabase database) : base(database)
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

            var betDetails = bet.SettlementDetails;

            var metaData = new Dictionary<string, object>
            {
                { "betDetails", betDetails}
            };

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = bet.TotalAmount,
                TotalAmount = bet.TotalAmount,
                TotalWin = bet.Betwin,
                MetaData = metaData
            };
        }
    }
}
