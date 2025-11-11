using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class PlinkoXEndGameInfoServiceMock : IEndGameInfoService
    {
        public PlinkoGameRound Round { get; set; }

        public PlinkoXEndGameInfoServiceMock(IPlinkoGameBetRepository _)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            if (Round == null || Round.TotalAmount == 0)
            {
                return await Task.FromResult(EndRoundInfoError.SB1001);
            }

            var result = new EndRoundInfoResult
            {
                EndTime = Round.Time,
                ValidBetAmount = Round.TotalAmount,
                TotalAmount = Round.TotalAmount,
                TotalWin = Round.BetWin
            };

            return await Task.FromResult(result);
        }
    }
}
