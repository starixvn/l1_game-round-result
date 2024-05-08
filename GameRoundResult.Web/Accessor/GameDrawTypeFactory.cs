using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameDrawTypeFactory
    {
        Task<(long, IEnumerable<object>)> GetGameDrawType(GetRoundResultRequest request, DateTime utcDate);
    }

    public class GameDrawType
    {
        public Task<(long, IEnumerable<object>)> GameDraw { get; set; }
    }

    public class GameDrawTypeFactory : IGameDrawTypeFactory
    {
        private readonly IGameRoundResultService gameRoundResultService;

        public GameDrawTypeFactory(IGameRoundResultService gameRoundResultService)
        {
            this.gameRoundResultService = gameRoundResultService;
        }

        public async Task<(long, IEnumerable<object>)> GetGameDrawType(GetRoundResultRequest request, DateTime utcDate)
        {
            Dictionary<GameType, (long, IEnumerable<object> )> roundResultType = new()
            {
                { GameType.BacBall1, await gameRoundResultService.GetGameDrawResultAsync
                <BacBall1Round, BacBallRoundResult, BacBallSettlementResult>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize) },
                
                { GameType.BacBall2, await gameRoundResultService.GetGameDrawResultAsync
                <BacBall2Round, BacBallRoundResult, BacBallSettlementResult>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize) },
                
                { GameType.LuckyNext1, await gameRoundResultService.GetGameDrawResultAsync
                <LuckyNext1Round, LuckyNextRoundResult, LuckyNextSettlementResult>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize) },
                
                { GameType.LuckyNext2, await gameRoundResultService.GetGameDrawResultAsync
                <LuckyNext2Round, LuckyNextRoundResult, LuckyNextSettlementResult>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize) },
            };

            return roundResultType[request.GameType];
        }
    }
}