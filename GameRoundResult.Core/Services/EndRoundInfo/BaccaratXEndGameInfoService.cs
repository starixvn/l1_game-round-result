using System;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BaccaratXEndGameInfoService : IEndGameInfoService
    {
        private readonly IGameBetRepository repository;

        public BaccaratXEndGameInfoService( IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var (round, bet) = await repository.GetAsync<BaccaratXRound, BaccaratXBet>(
                request.GameRoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameName);

            if(round == null || bet == null)
            {
                return EndRoundInfoError.SB1001;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount =  Math.Round(bet.TotalAmount,2),
                TotalAmount = Math.Round(bet.TotalAmount, 2),
                TotalWin = bet.Betwin
            };
        }
    }
}